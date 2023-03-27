namespace HelpDeskForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnNewTicket = new Button();
            cmbUsers = new ComboBox();
            btnNewUser = new Button();
            btnTickRes = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnNewTicket
            // 
            btnNewTicket.Enabled = false;
            btnNewTicket.Location = new Point(6, 22);
            btnNewTicket.Name = "btnNewTicket";
            btnNewTicket.Size = new Size(110, 23);
            btnNewTicket.TabIndex = 0;
            btnNewTicket.Text = "New Ticket";
            btnNewTicket.UseVisualStyleBackColor = true;
            btnNewTicket.Click += btnNewTicket_Click;
            // 
            // cmbUsers
            // 
            cmbUsers.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsers.FormattingEnabled = true;
            cmbUsers.Location = new Point(6, 22);
            cmbUsers.Name = "cmbUsers";
            cmbUsers.Size = new Size(121, 23);
            cmbUsers.TabIndex = 1;
            cmbUsers.SelectedIndexChanged += cmbUsers_SelectedIndexChanged;
            // 
            // btnNewUser
            // 
            btnNewUser.Location = new Point(6, 51);
            btnNewUser.Name = "btnNewUser";
            btnNewUser.Size = new Size(121, 23);
            btnNewUser.TabIndex = 3;
            btnNewUser.Text = "New User";
            btnNewUser.UseVisualStyleBackColor = true;
            btnNewUser.Click += btnNewUser_Click;
            // 
            // btnTickRes
            // 
            btnTickRes.Enabled = false;
            btnTickRes.Location = new Point(6, 51);
            btnTickRes.Name = "btnTickRes";
            btnTickRes.Size = new Size(110, 23);
            btnTickRes.TabIndex = 4;
            btnTickRes.Text = "Resolve Tickets";
            btnTickRes.UseVisualStyleBackColor = true;
            btnTickRes.Click += btnTickRes_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbUsers);
            groupBox1.Controls.Add(btnNewUser);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(137, 85);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "User";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnNewTicket);
            groupBox2.Controls.Add(btnTickRes);
            groupBox2.Location = new Point(155, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(126, 84);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tickets";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(289, 104);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnNewTicket;
        private ComboBox cmbUsers;
        private Button btnNewUser;
        private Button btnTickRes;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}