namespace Project.Application_Licenses
{
    partial class FrmRenewalApplicationLicense
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
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.ucFilterApplicationNewLicenseInfo1 = new Project.Application_Licenses.ucFilterApplicationNewLicenseInfo();
            this.btnRenew = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(144, 1);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(407, 34);
            this.guna2HtmlLabel1.TabIndex = 42;
            this.guna2HtmlLabel1.Text = "Renewal Locall License Application";
            // 
            // ucFilterApplicationNewLicenseInfo1
            // 
            this.ucFilterApplicationNewLicenseInfo1.Location = new System.Drawing.Point(12, 41);
            this.ucFilterApplicationNewLicenseInfo1.Name = "ucFilterApplicationNewLicenseInfo1";
            this.ucFilterApplicationNewLicenseInfo1.Size = new System.Drawing.Size(731, 598);
            this.ucFilterApplicationNewLicenseInfo1.TabIndex = 0;
            // 
            // btnRenew
            // 
            this.btnRenew.Animated = true;
            this.btnRenew.AutoRoundedCorners = true;
            this.btnRenew.BackColor = System.Drawing.Color.Gray;
            this.btnRenew.BorderRadius = 21;
            this.btnRenew.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btnRenew.CheckedState.Parent = this.btnRenew;
            this.btnRenew.CustomImages.Parent = this.btnRenew;
            this.btnRenew.FillColor = System.Drawing.Color.LightGray;
            this.btnRenew.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenew.ForeColor = System.Drawing.Color.Black;
            this.btnRenew.HoverState.Parent = this.btnRenew;
            this.btnRenew.Location = new System.Drawing.Point(639, 634);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.ShadowDecoration.Parent = this.btnRenew;
            this.btnRenew.Size = new System.Drawing.Size(92, 45);
            this.btnRenew.TabIndex = 43;
            this.btnRenew.Text = "Renew";
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.Animated = true;
            this.guna2Button1.AutoRoundedCorners = true;
            this.guna2Button1.BackColor = System.Drawing.Color.Gray;
            this.guna2Button1.BorderRadius = 21;
            this.guna2Button1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.FillColor = System.Drawing.Color.LightGray;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Location = new System.Drawing.Point(510, 634);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(92, 45);
            this.guna2Button1.TabIndex = 44;
            this.guna2Button1.Text = "Close";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // FrmRenewalApplicationLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 705);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.btnRenew);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.ucFilterApplicationNewLicenseInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRenewalApplicationLicense";
            this.Text = "Renewal Application License";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucFilterApplicationNewLicenseInfo ucFilterApplicationNewLicenseInfo1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button btnRenew;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}