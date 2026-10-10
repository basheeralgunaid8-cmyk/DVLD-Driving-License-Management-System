namespace Project.Application_Licenses
{
    partial class frmReleaseLicense
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
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.btnRenew = new Guna.UI2.WinForms.Guna2Button();
            this.ucFilterApplicaitonDetainLicense1 = new Project.Application_Licenses.ucFilterApplicaitonDetainLicense();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(243, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 45);
            this.label1.TabIndex = 3;
            this.label1.Text = "Release License ";
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
            this.guna2Button1.Location = new System.Drawing.Point(549, 575);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(92, 45);
            this.guna2Button1.TabIndex = 50;
            this.guna2Button1.Text = "Close";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
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
            this.btnRenew.Location = new System.Drawing.Point(666, 575);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.ShadowDecoration.Parent = this.btnRenew;
            this.btnRenew.Size = new System.Drawing.Size(92, 45);
            this.btnRenew.TabIndex = 49;
            this.btnRenew.Text = "Release";
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // ucFilterApplicaitonDetainLicense1
            // 
            this.ucFilterApplicaitonDetainLicense1.Location = new System.Drawing.Point(3, 57);
            this.ucFilterApplicaitonDetainLicense1.Name = "ucFilterApplicaitonDetainLicense1";
            this.ucFilterApplicaitonDetainLicense1.Size = new System.Drawing.Size(755, 512);
            this.ucFilterApplicaitonDetainLicense1.TabIndex = 51;
            this.ucFilterApplicaitonDetainLicense1.SearchClicked += new System.EventHandler<Project.Application_Licenses.ucFilterApplicaitonDetainLicense.SearchEventArgs>(this.ucFilterApplicaitonDetainLicense1_SearchClicked);
            // 
            // frmReleaseLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 634);
            this.Controls.Add(this.ucFilterApplicaitonDetainLicense1);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.btnRenew);
            this.Controls.Add(this.label1);
            this.Name = "frmReleaseLicense";
            this.Text = "Release  License";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button btnRenew;
        private ucFilterApplicaitonDetainLicense ucFilterApplicaitonDetainLicense1;
    }
}