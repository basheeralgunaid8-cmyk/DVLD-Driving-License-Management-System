namespace Project.Application_Licenses
{
    partial class frmReplacementForDamagedOrLost
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
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.btnRenew = new Guna.UI2.WinForms.Guna2Button();
            this.ucFilterLocalLicenseForLostorDamaged1 = new Project.Application_Licenses.ucFilterLocalLicenseForLostorDamaged();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(142, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(453, 34);
            this.lblTitle.TabIndex = 43;
            this.lblTitle.Text = "Replacement  Local License Application";
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
            this.guna2Button1.Location = new System.Drawing.Point(535, 542);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(92, 45);
            this.guna2Button1.TabIndex = 46;
            this.guna2Button1.Text = "Close";
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
            this.btnRenew.Location = new System.Drawing.Point(665, 542);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.ShadowDecoration.Parent = this.btnRenew;
            this.btnRenew.Size = new System.Drawing.Size(92, 45);
            this.btnRenew.TabIndex = 45;
            this.btnRenew.Text = "Renew";
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // ucFilterLocalLicenseForLostorDamaged1
            // 
            this.ucFilterLocalLicenseForLostorDamaged1.Location = new System.Drawing.Point(12, 52);
            this.ucFilterLocalLicenseForLostorDamaged1.Name = "ucFilterLocalLicenseForLostorDamaged1";
            this.ucFilterLocalLicenseForLostorDamaged1.Size = new System.Drawing.Size(751, 484);
            this.ucFilterLocalLicenseForLostorDamaged1.TabIndex = 44;
            this.ucFilterLocalLicenseForLostorDamaged1.SearchClicked += new System.EventHandler<Project.Application_Licenses.ucFilterLocalLicenseForLostorDamaged.SearchEventArgs>(this.ucFilterLocalLicenseForLostorDamaged1_SearchClicked);
            // 
            // frmReplacementForDamagedOrLost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 594);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.btnRenew);
            this.Controls.Add(this.ucFilterLocalLicenseForLostorDamaged1);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReplacementForDamagedOrLost";
            this.Text = "Replacement For Damaged Or Lost";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private ucFilterLocalLicenseForLostorDamaged ucFilterLocalLicenseForLostorDamaged1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button btnRenew;
    }
}