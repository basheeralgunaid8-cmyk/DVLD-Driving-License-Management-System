namespace Project.Sechdule_Tests
{
    partial class FrmUpdateWrittenTestAppointment
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
            this.ucRetakeTest1 = new Project.Sechdule_Tests.ucRetakeTest();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.ucWrittenTest1 = new Project.Sechdule_Tests.ucWrittenTest();
            this.dtpDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ucRetakeTest1
            // 
            this.ucRetakeTest1.Enabled = false;
            this.ucRetakeTest1.Location = new System.Drawing.Point(0, 433);
            this.ucRetakeTest1.Name = "ucRetakeTest1";
            this.ucRetakeTest1.Size = new System.Drawing.Size(380, 107);
            this.ucRetakeTest1.TabIndex = 31;
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
            this.btnSave.Location = new System.Drawing.Point(210, 558);
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
            this.btnClose.Location = new System.Drawing.Point(48, 558);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(92, 45);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ucWrittenTest1
            // 
            this.ucWrittenTest1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucWrittenTest1.Location = new System.Drawing.Point(0, 0);
            this.ucWrittenTest1.Name = "ucWrittenTest1";
            this.ucWrittenTest1.Size = new System.Drawing.Size(380, 435);
            this.ucWrittenTest1.TabIndex = 32;
            // 
            // dtpDate
            // 
            this.dtpDate.Animated = true;
            this.dtpDate.AutoRoundedCorners = true;
            this.dtpDate.BorderRadius = 17;
            this.dtpDate.CheckedState.Parent = this.dtpDate;
            this.dtpDate.FillColor = System.Drawing.Color.Gray;
            this.dtpDate.ForeColor = System.Drawing.SystemColors.Control;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpDate.HoverState.Parent = this.dtpDate;
            this.dtpDate.Location = new System.Drawing.Point(146, 301);
            this.dtpDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.ShadowDecoration.Parent = this.dtpDate;
            this.dtpDate.Size = new System.Drawing.Size(170, 36);
            this.dtpDate.TabIndex = 33;
            this.dtpDate.Value = new System.DateTime(2026, 9, 10, 21, 41, 18, 440);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(42, 117);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(272, 32);
            this.lblTitle.TabIndex = 35;
            this.lblTitle.Text = "Written Schedule Test";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.ForeColor = System.Drawing.Color.Maroon;
            this.lblNote.Location = new System.Drawing.Point(12, 150);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(18, 17);
            this.lblNote.TabIndex = 36;
            this.lblNote.Text = "??";
            // 
            // FrmUpdateWrittenTestAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 624);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.ucWrittenTest1);
            this.Controls.Add(this.ucRetakeTest1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmUpdateWrittenTestAppointment";
            this.Text = "Update Written Test Appointment";
            this.Load += new System.EventHandler(this.FrmUpdateWrittenTestAppointment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucRetakeTest ucRetakeTest1;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private ucWrittenTest ucWrittenTest1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNote;
    }
}