namespace HelpDeskForm
{
    partial class Add_User
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txbUser = new TextBox();
            txbFirst = new TextBox();
            txbLast = new TextBox();
            dtpBirth = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnSubmit = new Button();
            btnClear = new Button();
            SuspendLayout();
            // 
            // txbUser
            // 
            txbUser.Location = new Point(92, 6);
            txbUser.Name = "txbUser";
            txbUser.Size = new Size(84, 23);
            txbUser.TabIndex = 1;
            // 
            // txbFirst
            // 
            txbFirst.Location = new Point(92, 35);
            txbFirst.Name = "txbFirst";
            txbFirst.Size = new Size(84, 23);
            txbFirst.TabIndex = 2;
            // 
            // txbLast
            // 
            txbLast.Location = new Point(92, 64);
            txbLast.Name = "txbLast";
            txbLast.Size = new Size(84, 23);
            txbLast.TabIndex = 3;
            // 
            // dtpBirth
            // 
            dtpBirth.CustomFormat = "MM/dd/yyyy";
            dtpBirth.Format = DateTimePickerFormat.Custom;
            dtpBirth.Location = new Point(92, 93);
            dtpBirth.MaxDate = new DateTime(2023, 3, 24, 12, 36, 19, 0);
            dtpBirth.Name = "dtpBirth";
            dtpBirth.Size = new Size(84, 23);
            dtpBirth.TabIndex = 4;
            dtpBirth.Value = new DateTime(2023, 3, 24, 0, 0, 0, 0);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 9);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 2;
            label1.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 38);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 2;
            label2.Text = "First Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 64);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 2;
            label3.Text = "Last Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 99);
            label4.Name = "label4";
            label4.Size = new Size(76, 15);
            label4.TabIndex = 2;
            label4.Text = "Date of Birth:";
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(92, 122);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(84, 23);
            btnSubmit.TabIndex = 6;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(12, 122);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 5;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // Add_User
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(217, 157);
            Controls.Add(btnClear);
            Controls.Add(btnSubmit);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpBirth);
            Controls.Add(txbLast);
            Controls.Add(txbFirst);
            Controls.Add(txbUser);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Add_User";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "New User";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txbUser;
        private TextBox txbFirst;
        private TextBox txbLast;
        private DateTimePicker dtpBirth;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnSubmit;
        private Button btnClear;
    }
}