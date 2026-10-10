namespace Project.Sechdule_Tests
{
    partial class FrmScheduleStreetTest
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
            this.dtpDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.ucRetakeTest1 = new Project.Sechdule_Tests.ucRetakeTest();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // ucStreetTest1
            // 
            this.ucStreetTest1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucStreetTest1.Location = new System.Drawing.Point(0, 0);
            this.ucStreetTest1.Name = "ucStreetTest1";
            this.ucStreetTest1.Size = new System.Drawing.Size(360, 456);
            this.ucStreetTest1.TabIndex = 0;
            // 
            // dtpDate
            // 
            this.dtpDate.Animated = true;
            this.dtpDate.AutoRoundedCorners = true;
            this.dtpDate.BorderRadius = 15;
            this.dtpDate.CheckedState.Parent = this.dtpDate;
            this.dtpDate.FillColor = System.Drawing.Color.DimGray;
            this.dtpDate.ForeColor = System.Drawing.Color.White;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpDate.HoverState.Parent = this.dtpDate;
            this.dtpDate.Location = new System.Drawing.Point(151, 333);
            this.dtpDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.ShadowDecoration.Parent = this.dtpDate;
            this.dtpDate.Size = new System.Drawing.Size(163, 32);
            this.dtpDate.TabIndex = 35;
            this.dtpDate.Value = new System.DateTime(2026, 9, 10, 20, 50, 40, 621);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(20, 138);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(271, 39);
            this.lblTitle.TabIndex = 34;
            this.lblTitle.Text = "Schedule Street Test";
            // 
            // ucRetakeTest1
            // 
            this.ucRetakeTest1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucRetakeTest1.Enabled = false;
            this.ucRetakeTest1.Location = new System.Drawing.Point(0, 462);
            this.ucRetakeTest1.Name = "ucRetakeTest1";
            this.ucRetakeTest1.Size = new System.Drawing.Size(360, 107);
            this.ucRetakeTest1.TabIndex = 33;
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
            this.btnSave.Location = new System.Drawing.Point(222, 575);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShadowDecoration.Parent = this.btnSave;
            this.btnSave.Size = new System.Drawing.Size(92, 45);
            this.btnSave.TabIndex = 32;
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
            this.btnClose.Location = new System.Drawing.Point(34, 575);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(92, 45);
            this.btnClose.TabIndex = 31;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmScheduleStreetTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 644);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ucRetakeTest1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucStreetTest1);
            this.Name = "FrmScheduleStreetTest";
            this.Text = "FrmScheduleStreetTest";
            this.Load += new System.EventHandler(this.FrmScheduleStreetTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucStreetTest ucStreetTest1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private ucRetakeTest ucRetakeTest1;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}