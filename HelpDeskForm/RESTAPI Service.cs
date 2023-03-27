using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using HelpDeskAssignment.DTOObjects;
using HelpDeskModelProject;
using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;

namespace HelpDeskForm
{
    public class RESTAPI_Service
    {
        private readonly HttpClient _httpClient;
        public RESTAPI_Service(string baseUrl)
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        public async Task<HttpResponseMessage> LogUserIn(HelpDeskModelProject.User u)
        {
            var payload = new StringContent(JsonConvert.SerializeObject(u), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("/api/Auth/login", payload);
            return response;
        }

        public async Task<HttpResponseMessage> GetAllUsers() => await _httpClient.GetAsync("/api/Users");
        //{
        //    return await _httpClient.GetAsync("/api/Users");
        //}

        public async Task<int> GetTotalTicketCount()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Tickets/count");
            string responseContent = await response.Content.ReadAsStringAsync();
            int totalTickets = JsonConvert.DeserializeObject<int>(responseContent);
            return totalTickets;
        }

        public async Task<(List<Tickets>, int totalTickets)> GetAllTickets(int skip, int take, int PAGESIZE)
        {
            var ticketList = new List<Tickets>();
            int totalTickets = 0;
            int retrieved = 0;

            do
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"api/Tickets?skip={skip}&take={take}");

                string responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeAnonymousType(responseContent, new { totalTickets, tickets = new List<Tickets>() });

                totalTickets = result.totalTickets;
                ticketList.AddRange(result.tickets);

                retrieved += result.tickets.Count;
                skip = retrieved;
                take = Math.Min(PAGESIZE, totalTickets - retrieved);
            }
            while (retrieved < totalTickets);

            return (ticketList, totalTickets);
        }

        //Endpoint from our swagger api
        //Token retrieved previously
        public async Task<HttpResponseMessage> GetProtectedPage(string endpoint, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
            return response;
        }

        public async Task<HttpResponseMessage> PostTicket(Tickets ticket)
        {
            var submitter = await _httpClient.GetAsync($"api/Users/{ticket.TicketSubmitterID}");
            if (!submitter.IsSuccessStatusCode)
                return submitter;

            var submitterJson = await submitter.Content.ReadAsStringAsync();
            var submitterObj = JsonConvert.DeserializeObject<HelpDeskModelProject.User>(submitterJson);
            ticket.TicketSubmitter = submitterObj;

            var json = JsonConvert.SerializeObject(ticket);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("api/Tickets", content);
            return response;
        }

        public async Task<HttpResponseMessage> PostUser(HelpDeskModelProject.User user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("api/Users", content);
            return response;
        }

        public async Task<HttpResponseMessage> PutTicketsX(Tickets ticket)
        {
            var json = JsonConvert.SerializeObject(ticket);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync("api/Tickets", content);
            return response;
        }
    }
}
