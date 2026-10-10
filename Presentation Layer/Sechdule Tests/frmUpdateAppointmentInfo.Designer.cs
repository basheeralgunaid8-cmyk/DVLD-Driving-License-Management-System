namespace Project.Sechdule_Tests
{
    partial class frmUpdateAppointmentInfo
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
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.dtpRescheduleDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblNote = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.ucRetakeTest1 = new Project.Sechdule_Tests.ucRetakeTest();
            this.ucVisionTest1 = new Project.Sechdule_Tests.ucVisionTest();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.btnSave.Location = new System.Drawing.Point(232, 593);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShadowDecoration.Parent = this.btnSave;
            this.btnSave.Size = new System.Drawing.Size(92, 45);
            this.btnSave.TabIndex = 24;
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
            this.btnClose.Location = new System.Drawing.Point(27, 593);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(92, 45);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.dtpRescheduleDate.Location = new System.Drawing.Point(156, 319);
            this.dtpRescheduleDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpRescheduleDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpRescheduleDate.Name = "dtpRescheduleDate";
            this.dtpRescheduleDate.ShadowDecoration.Parent = this.dtpRescheduleDate;
            this.dtpRescheduleDate.Size = new System.Drawing.Size(168, 32);
            this.dtpRescheduleDate.TabIndex = 26;
            this.dtpRescheduleDate.Value = new System.DateTime(2026, 8, 29, 18, 21, 20, 752);
            // 
            // lblNote
            // 
            this.lblNote.BackColor = System.Drawing.Color.Transparent;
            this.lblNote.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.ForeColor = System.Drawing.Color.Red;
            this.lblNote.Location = new System.Drawing.Point(12, 147);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(3, 2);
            this.lblNote.TabIndex = 28;
            // 
            // ucRetakeTest1
            // 
            this.ucRetakeTest1.Enabled = false;
            this.ucRetakeTest1.Location = new System.Drawing.Point(12, 453);
            this.ucRetakeTest1.Name = "ucRetakeTest1";
            this.ucRetakeTest1.Size = new System.Drawing.Size(357, 107);
            this.ucRetakeTest1.TabIndex = 27;
            // 
            // ucVisionTest1
            // 
            this.ucVisionTest1.Location = new System.Drawing.Point(11, 11);
            this.ucVisionTest1.Margin = new System.Windows.Forms.Padding(2);
            this.ucVisionTest1.Name = "ucVisionTest1";
            this.ucVisionTest1.Size = new System.Drawing.Size(358, 437);
            this.ucVisionTest1.TabIndex = 25;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(80, 94);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(175, 32);
            this.lblTitle.TabIndex = 34;
            this.lblTitle.Text = "Schedule Test";
            // 
            // frmUpdateAppointmentInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(391, 669);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.ucRetakeTest1);
            this.Controls.Add(this.dtpRescheduleDate);
            this.Controls.Add(this.ucVisionTest1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmUpdateAppointmentInfo";
            this.Text = "Update Appointment Info";
            this.Load += new System.EventHandler(this.frmUpdateAppointmentInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private ucVisionTest ucVisionTest1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpRescheduleDate;
        private ucRetakeTest ucRetakeTest1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNote;
        private System.Windows.Forms.Label lblTitle;
    }
}