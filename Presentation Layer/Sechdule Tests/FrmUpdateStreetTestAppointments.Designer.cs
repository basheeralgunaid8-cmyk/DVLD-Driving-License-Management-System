namespace Project.Sechdule_Tests
{
    partial class FrmUpdateStreetTestAppointments
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
            this.ucStreetTest1 = new Project.Sechdule_Tests.ucStreetTest();
            this.ucRetakeTest1 = new Project.Sechdule_Tests.ucRetakeTest();
            this.dtpRescheduleDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNote = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ucStreetTest1
            // 
            this.ucStreetTest1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucStreetTest1.Location = new System.Drawing.Point(0, 0);
            this.ucStreetTest1.Name = "ucStreetTest1";
            this.ucStreetTest1.Size = new System.Drawing.Size(352, 452);
            this.ucStreetTest1.TabIndex = 0;
            // 
            // ucRetakeTest1
            // 
            this.ucRetakeTest1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucRetakeTest1.Enabled = false;
            this.ucRetakeTest1.Location = new System.Drawing.Point(0, 458);
            this.ucRetakeTest1.Name = "ucRetakeTest1";
            this.ucRetakeTest1.Size = new System.Drawing.Size(352, 107);
            this.ucRetakeTest1.TabIndex = 31;
            // 
            // dtpRescheduleDate
            // 
            this.dtpRescheduleDate.Animated = true;
            this.dtpRescheduleDate.AutoRoundedCorners = true;
            this.dtpRescheduleDate.BorderRadius = 15;
            this.dtpRescheduleDate.CheckedState.Parent = this.dtpRescheduleDate;
            this.dtpRescheduleDate.FillColor = System.Drawing.Color.White;
            this.dtpRescheduleDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpRescheduleDate.HoverState.Parent = this.dtpRescheduleDate;
            this.dtpRescheduleDate.Location = new System.Drawing.Point(144, 339);
            this.dtpRescheduleDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpRescheduleDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpRescheduleDate.Name = "dtpRescheduleDate";
            this.dtpRescheduleDate.ShadowDecoration.Parent = this.dtpRescheduleDate;
            this.dtpRescheduleDate.Size = new System.Drawing.Size(168, 32);
            this.dtpRescheduleDate.TabIndex = 30;
            this.dtpRescheduleDate.Value = new System.DateTime(2026, 8, 29, 18, 21, 20, 752);
            // 
            // btnSave
            // 
            this.btnSave.Animated = true;
            this.btnSave.AutoRoundedCorners = true;
            this.btnSave.BackColor = System.Drawing.Color.Gray;
            this.btnSave.BorderRadius = 21;
            this.btnSave.CheckedState.Parent = this.btnSave;
            this.btnSave.CustomImages.Parent = this.btnSave;
            this.btnSave.FillColor = System.Drawing.Color.LightGray;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.HoverState.Parent = this.btnSave;
            this.btnSave.Location = new System.Drawing.Point(204, 571);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShadowDecoration.Parent = this.btnSave;
            this.btnSave.Size = new System.Drawing.Size(92, 45);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Animated = true;
            this.btnClose.AutoRoundedCorners = true;
            this.btnClose.BackColor = System.Drawing.Color.Gray;
            this.btnClose.BorderRadius = 21;
            this.btnClose.CheckedState.Parent = this.btnClose;
            this.btnClose.CustomImages.Parent = this.btnClose;
            this.btnClose.FillColor = System.Drawing.Color.LightGray;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.HoverState.Parent = this.btnClose;
            this.btnClose.Location = new System.Drawing.Point(32, 571);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(92, 45);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(41, 134);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(271, 39);
            this.lblTitle.TabIndex = 35;
            this.lblTitle.Text = "Schedule Street Test";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNote.Location = new System.Drawing.Point(12, 176);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(39, 16);
            this.lblNote.TabIndex = 36;
            this.lblNote.Text = "____";
            // 
            // FrmUpdateStreetTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 628);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ucRetakeTest1);
            this.Controls.Add(this.dtpRescheduleDate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucStreetTest1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmUpdateStreetTestAppointments";
            this.Text = "Update Street Test Appointments";
            this.Load += new System.EventHandler(this.FrmUpdateStreetTestAppointments_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucStreetTest ucStreetTest1;
        private ucRetakeTest ucRetakeTest1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpRescheduleDate;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private System.Windows.Forms.Label lblNote;
    }
}