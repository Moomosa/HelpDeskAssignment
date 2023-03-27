using HelpDeskAssignment.DTOObjects;
using HelpDeskModelProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace HelpDeskForm
{
    public partial class ResolveTickets : Form
    {
        int userid;
        List<Tickets> TicketList;
        int selectedTicketId;
        bool seeAll;
        public ResolveTickets(int userID, List<Tickets> ticketList)
        {
            InitializeComponent();
            userid = userID;
            TicketList = ticketList;
            LoadList();
        }

        private void LoadList()
        {
            lsvTickets.Clear();

            lsvTickets.Columns.Add("Ticket ID", 60, HorizontalAlignment.Left);
            lsvTickets.Columns.Add("Submitter", 80, HorizontalAlignment.Left);
            lsvTickets.Columns.Add("Description", 300, HorizontalAlignment.Left);
            lsvTickets.Columns.Add("Escalated", 70, HorizontalAlignment.Left);
            lsvTickets.Columns.Add("Time Submitted", 135, HorizontalAlignment.Left);
            if (seeAll)
            {
                lsvTickets.Columns.Add("Resolved", 60, HorizontalAlignment.Left);
                lsvTickets.Columns.Add("Resolver", 80, HorizontalAlignment.Left);
                lsvTickets.Columns.Add("Resolution Comment", 300, HorizontalAlignment.Left);
                lsvTickets.Columns.Add("Time Resolved", 135, HorizontalAlignment.Left);
            }

            foreach (Tickets ticket in TicketList)
            {
                if (ticket.Resolved && !seeAll)
                    continue;
                ListViewItem item = new ListViewItem();
                item.Text = ticket.TicketID.ToString();
                item.SubItems.Add(ticket.TicketSubmitter.Username);
                item.SubItems.Add(ticket.Description);
                item.SubItems.Add(ticket.Escalated ? "Yes" : "No");
                item.SubItems.Add(ticket.TimeSubmitted.ToString());
                if (seeAll)
                {
                    item.SubItems.Add(ticket.Resolved ? "Yes" : "No");
                    item.SubItems.Add(ticket.TicketResolver != null ? ticket.TicketResolver.Username : "");
                    item.SubItems.Add(ticket.ResolutionComment ?? "");
                    item.SubItems.Add(ticket.TimeResolved != null ? ticket.TimeResolved.ToString() : "");
                }
                lsvTickets.Items.Add(item);

            }
        }

        private void chbSeeRes_CheckedChanged(object sender, EventArgs e)
        {
            seeAll = !seeAll;
            if (seeAll)
                lblTick.Text = "All Tickets:";
            else
                lblTick.Text = "Unresolved Tickets:";
            LoadList();
        }

        private async void btnResolve_Click(object sender, EventArgs e)
        {
            if (selectedTicketId > 0)
            {
                Tickets selectedTicket = TicketList.FirstOrDefault(t => t.TicketID == selectedTicketId);
                selectedTicket.ResolutionComment = rtbResCom.Text;
                selectedTicket.Resolved = true;
                selectedTicket.TicketResolverID = userid;
                selectedTicket.TimeResolved = DateTime.Now;

                RESTAPI_Service service = new("https://localhost:7059/");
                var result = await service.PutTicketsX(selectedTicket);

                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Ticket updated successfully.");
                    Close();
                }
                else
                    MessageBox.Show("Error adding ticket." + result.ReasonPhrase);
            }
            else
                MessageBox.Show("Please select a ticket.");
        }

        private void lsvTickets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvTickets.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lsvTickets.SelectedItems[0];
                selectedTicketId = int.Parse(selectedItem.Text);
            }
            Tickets selectedTicket = TicketList.FirstOrDefault(t => t.TicketID == selectedTicketId);

            if (selectedTicket != null && selectedTicket.Resolved)
            {
                grpRes.Visible = false;
            }
            else
            {
                grpRes.Visible = true;
            }
        }
    }
}
