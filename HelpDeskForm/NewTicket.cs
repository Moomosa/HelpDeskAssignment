using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HelpDeskAssignment.DTOObjects;
using HelpDeskModelProject;


namespace HelpDeskForm
{
    public partial class NewTicket : Form
    {
        int userid;
        public NewTicket(int userId)
        {
            InitializeComponent();
            userid = userId;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            var ticket = new Tickets
            {
                TicketSubmitterID = userid,
                Description = rtbDesc.Text
            };

            RESTAPI_Service service = new("https://localhost:7059/");
            var result = await service.PostTicket(ticket);

            if (result.IsSuccessStatusCode)
            {
                MessageBox.Show("Ticket added successfully.");
                Close();
            }
            else
            {
                MessageBox.Show("Error adding ticket." + result.ReasonPhrase);
            }
        }
    }
}
