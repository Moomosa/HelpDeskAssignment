namespace HelpDeskForm
{
    partial class NewTicket
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
            rtbDesc = new RichTextBox();
            label1 = new Label();
            btnSubmit = new Button();
            SuspendLayout();
            // 
            // rtbDesc
            // 
            rtbDesc.Location = new Point(12, 27);
            rtbDesc.Name = "rtbDesc";
            rtbDesc.Size = new Size(257, 114);
            rtbDesc.TabIndex = 0;
            rtbDesc.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 1;
            label1.Text = "Description:";
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(12, 147);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(105, 23);
            btnSubmit.TabIndex = 2;
            btnSubmit.Text = "Submit Ticket";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // NewTicket
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(278, 183);
            Controls.Add(btnSubmit);
            Controls.Add(label1);
            Controls.Add(rtbDesc);
            Name = "NewTicket";
            StartPosition = FormStartPosition.CenterParent;
            Text = "NewTicket";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtbDesc;
        private Label label1;
        private Button btnSubmit;
    }
}