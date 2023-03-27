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

namespace HelpDeskForm
{
    public partial class Add_User : Form
    {
        public Add_User()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txbUser.Clear();
            txbFirst.Clear();
            txbLast.Clear();
            dtpBirth.ResetText();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            var user = new User
            {
                Username = txbUser.Text,
                FirstName = txbFirst.Text,
                LastName = txbLast.Text,
                Birthdate = dtpBirth.Value,
                RegisterDate = DateTime.Now
            };

            RESTAPI_Service service = new("https://localhost:7059/");
            var result = await service.PostUser(user);

            if (result.IsSuccessStatusCode)
            {
                MessageBox.Show("User added successfully.");
                Close();
            }
            else
            {
                //This is a great debugging line
                MessageBox.Show("Error adding user." + result.ReasonPhrase);
            }
        }
    }
}
