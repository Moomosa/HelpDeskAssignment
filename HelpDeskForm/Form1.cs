using HelpDeskModelProject;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Drawing.Printing;

namespace HelpDeskForm
{
    public partial class Form1 : Form
    {
        List<User> UserList;
        List<Tickets> TicketList;
        int userId;

        public Form1()
        {
            //https://localhost:7059/  This is the database location
            InitializeComponent();

            //All this to load all users into the ComboBox
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            RESTAPI_Service service = new("https://localhost:7059/");
            var a = await service.GetAllUsers();
            var stringMsg = a.Content.ReadAsStringAsync();
            UserList = JsonConvert.DeserializeObject<List<User>>(stringMsg.Result);
            UserList.Sort((x, y) => x.Username.CompareTo(y.Username));

            TicketList = new();
            const int PAGESIZE = 4;
            int totalTickets = await service.GetTotalTicketCount();
            int retrieved = 0;
            int skip = 0;
            do
            {
                int numToRetrieve = Math.Min(PAGESIZE, totalTickets - retrieved);
                var (tickets, totalNumTickets) = await service.GetAllTickets(skip, numToRetrieve, PAGESIZE);
                TicketList.AddRange(tickets);
                retrieved += numToRetrieve;
                skip += PAGESIZE;
            }
            while (retrieved < totalTickets);
            TicketList.Sort((t1, t2) => t1.TicketID.CompareTo(t2.TicketID));


            //var b = await service.GetAllTickets();
            //var stringMessage = b.Content.ReadAsStringAsync();
            //TicketList = JsonConvert.DeserializeObject<List<Tickets>>(stringMessage.Result);

            cmbUsers.SelectedIndexChanged -= cmbUsers_SelectedIndexChanged;
            cmbUsers.DisplayMember = "Username";
            cmbUsers.ValueMember = "ID";
            cmbUsers.DataSource = UserList;
            cmbUsers.SelectedValue = -1;
            cmbUsers.SelectedIndexChanged += cmbUsers_SelectedIndexChanged;

        }

        private void btnNewTicket_Click(object sender, EventArgs e)
        {
            if (userId != -1)
            {
                NewTicket newTicketForm = new(userId);
                newTicketForm.ShowDialog();
                LoadDataAsync();
            }
            else MessageBox.Show("Please select a User.");
        }

        private void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUsers.SelectedValue != null)
            {
                userId = (int)cmbUsers.SelectedValue;
                btnNewTicket.Enabled = true;
                btnTickRes.Enabled = true;
            }
        }


        private void btnNewUser_Click(object sender, EventArgs e)
        {
            Add_User add_User = new();
            add_User.ShowDialog();

            cmbUsers.Items.Clear();
            LoadDataAsync();
        }

        private async void button_Click(object sender, EventArgs e)
        {
            //This is the example to get all users.
            //Use this style for all use of the database

            RESTAPI_Service service = new("https://localhost:7059/");
            var a = await service.GetAllUsers();
            var stringMsg = a.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<List<User>>(stringMsg.Result);

        }

        private void btnTickRes_Click(object sender, EventArgs e)
        {
            ResolveTickets resTick = new(userId, TicketList);
            resTick.ShowDialog();
        }
    }
}