namespace HelpDeskForm
{
    partial class ResolveTickets
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
            lsvTickets = new ListView();
            lblTick = new Label();
            chbSeeRes = new CheckBox();
            grpRes = new GroupBox();
            label1 = new Label();
            rtbResCom = new RichTextBox();
            btnResolve = new Button();
            grpRes.SuspendLayout();
            SuspendLayout();
            // 
            // lsvTickets
            // 
            lsvTickets.FullRowSelect = true;
            lsvTickets.Location = new Point(12, 33);
            lsvTickets.MultiSelect = false;
            lsvTickets.Name = "lsvTickets";
            lsvTickets.Size = new Size(776, 170);
            lsvTickets.TabIndex = 0;
            lsvTickets.UseCompatibleStateImageBehavior = false;
            lsvTickets.View = View.Details;
            lsvTickets.SelectedIndexChanged += lsvTickets_SelectedIndexChanged;
            // 
            // lblTick
            // 
            lblTick.AutoSize = true;
            lblTick.Location = new Point(12, 9);
            lblTick.Name = "lblTick";
            lblTick.Size = new Size(108, 15);
            lblTick.TabIndex = 1;
            lblTick.Text = "Unresolved Tickets:";
            // 
            // chbSeeRes
            // 
            chbSeeRes.AutoSize = true;
            chbSeeRes.Location = new Point(688, 8);
            chbSeeRes.Name = "chbSeeRes";
            chbSeeRes.Size = new Size(100, 19);
            chbSeeRes.TabIndex = 2;
            chbSeeRes.Text = "See All Tickets";
            chbSeeRes.UseVisualStyleBackColor = true;
            chbSeeRes.CheckedChanged += chbSeeRes_CheckedChanged;
            // 
            // grpRes
            // 
            grpRes.Controls.Add(label1);
            grpRes.Controls.Add(rtbResCom);
            grpRes.Controls.Add(btnResolve);
            grpRes.Location = new Point(12, 209);
            grpRes.Name = "grpRes";
            grpRes.Size = new Size(216, 173);
            grpRes.TabIndex = 3;
            grpRes.TabStop = false;
            grpRes.Text = "Ticket Resolution";
            grpRes.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 2;
            label1.Text = "Comment:";
            // 
            // rtbResCom
            // 
            rtbResCom.Location = new Point(6, 37);
            rtbResCom.Name = "rtbResCom";
            rtbResCom.Size = new Size(201, 96);
            rtbResCom.TabIndex = 1;
            rtbResCom.Text = "";
            // 
            // btnResolve
            // 
            btnResolve.Location = new Point(6, 139);
            btnResolve.Name = "btnResolve";
            btnResolve.Size = new Size(75, 23);
            btnResolve.TabIndex = 0;
            btnResolve.Text = "Resolve";
            btnResolve.UseVisualStyleBackColor = true;
            btnResolve.Click += btnResolve_Click;
            // 
            // ResolveTickets
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 393);
            Controls.Add(grpRes);
            Controls.Add(chbSeeRes);
            Controls.Add(lblTick);
            Controls.Add(lsvTickets);
            Name = "ResolveTickets";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ResolveTickets";
            grpRes.ResumeLayout(false);
            grpRes.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lsvTickets;
        private Label lblTick;
        private CheckBox chbSeeRes;
        private GroupBox grpRes;
        private RichTextBox rtbResCom;
        private Button btnResolve;
        private Label label1;
    }
}