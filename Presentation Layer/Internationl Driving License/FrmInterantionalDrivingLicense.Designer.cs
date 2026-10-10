namespace Project.Internationl_Driving_License
{
    partial class FrmInterantionalDrivingLicense
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
            this.ucFilterDrivingLicense1 = new Project.Internationl_Driving_License.ucFilterDrivingLicense();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SuspendLayout();
            // 
            // ucFilterDrivingLicense1
            // 
            this.ucFilterDrivingLicense1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucFilterDrivingLicense1.Location = new System.Drawing.Point(12, 51);
            this.ucFilterDrivingLicense1.Name = "ucFilterDrivingLicense1";
            this.ucFilterDrivingLicense1.Size = new System.Drawing.Size(795, 655);
            this.ucFilterDrivingLicense1.TabIndex = 0;
            this.ucFilterDrivingLicense1.SearchClicked += new System.EventHandler<Project.Internationl_Driving_License.ucFilterDrivingLicense.SearchEventArgs>(this.ucFilterDrivingLicense1_SearchClicked);
            this.ucFilterDrivingLicense1.IssueClicked += new System.EventHandler(this.ucFilterDrivingLicense1_IssueClicked);
            // 
            // btnClose
            // 
            this.btnClose.Animated = true;
            this.btnClose.AutoRoundedCorners = true;
            this.btnClose.BackColor = System.Drawing.Color.Gray;
            this.btnClose.BorderRadius = 22;
            this.btnClose.CheckedState.Parent = this.btnClose;
            this.btnClose.CustomImages.Parent = this.btnClose;
            this.btnClose.FillColor = System.Drawing.Color.LightGray;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.HoverState.Parent = this.btnClose;
            this.btnClose.Location = new System.Drawing.Point(608, 649);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(92, 46);
            this.btnClose.TabIndex = 40;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(199, 7);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(391, 38);
            this.guna2HtmlLabel1.TabIndex = 41;
            this.guna2HtmlLabel1.Text = "International License Application";
            // 
            // FrmInterantionalDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 742);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucFilterDrivingLicense1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmInterantionalDrivingLicense";
            this.Text = "Interantional Driving License";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucFilterDrivingLicense ucFilterDrivingLicense1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}