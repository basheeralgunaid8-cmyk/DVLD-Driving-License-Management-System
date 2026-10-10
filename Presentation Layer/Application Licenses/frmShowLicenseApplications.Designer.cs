namespace Project.Application_Licenses
{
    partial class frmShowLicenseApplications
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
            this.ucDrivingLicenseApplicationInfo1 = new Project.Application_Licenses.ucDrivingLicenseApplicationInfo();
            this.ucLicenseApplicationBasicInfo1 = new Project.Application_Licenses.ucLicenseApplicationBasicInfo();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SuspendLayout();
            // 
            // ucDrivingLicenseApplicationInfo1
            // 
            this.ucDrivingLicenseApplicationInfo1.BackColor = System.Drawing.Color.Transparent;
            this.ucDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(25, 67);
            this.ucDrivingLicenseApplicationInfo1.Name = "ucDrivingLicenseApplicationInfo1";
            this.ucDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(755, 148);
            this.ucDrivingLicenseApplicationInfo1.TabIndex = 0;
            // 
            // ucLicenseApplicationBasicInfo1
            // 
            this.ucLicenseApplicationBasicInfo1.BackColor = System.Drawing.Color.Transparent;
            this.ucLicenseApplicationBasicInfo1.Location = new System.Drawing.Point(25, 247);
            this.ucLicenseApplicationBasicInfo1.Name = "ucLicenseApplicationBasicInfo1";
            this.ucLicenseApplicationBasicInfo1.Size = new System.Drawing.Size(755, 210);
            this.ucLicenseApplicationBasicInfo1.TabIndex = 1;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(221, 12);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(332, 39);
            this.guna2HtmlLabel1.TabIndex = 2;
            this.guna2HtmlLabel1.Text = "Show Application Details";
            // 
            // frmShowLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(825, 504);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.ucLicenseApplicationBasicInfo1);
            this.Controls.Add(this.ucDrivingLicenseApplicationInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowLicenseApplications";
            this.Text = "Show Local Driving License Application Info";
            this.Load += new System.EventHandler(this.frmShowLicenseApplications_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucDrivingLicenseApplicationInfo ucDrivingLicenseApplicationInfo1;
        private ucLicenseApplicationBasicInfo ucLicenseApplicationBasicInfo1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}