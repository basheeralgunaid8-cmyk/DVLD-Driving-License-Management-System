namespace Project.Application_Licenses
{
    partial class ucFilterLocalLicenseForLostorDamaged
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ucDrivingLicenseInfo1 = new Project.Application_Licenses.ucDrivingLicenseInfo();
            this.ucReplacementApplicaiontbasicinfo1 = new Project.Application_Licenses.ucReplacementApplicaiontbasicinfo();
            this.gbReplacement = new System.Windows.Forms.GroupBox();
            this.chDamaged = new System.Windows.Forms.CheckBox();
            this.chLost = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.gbReplacement.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(566, 78);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // btnSearch
            // 
            this.btnSearch.Animated = true;
            this.btnSearch.AutoRoundedCorners = true;
            this.btnSearch.BorderRadius = 17;
            this.btnSearch.CheckedState.Parent = this.btnSearch;
            this.btnSearch.CustomImages.Parent = this.btnSearch;
            this.btnSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.HoverState.Parent = this.btnSearch;
            this.btnSearch.Location = new System.Drawing.Point(456, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.ShadowDecoration.Parent = this.btnSearch;
            this.btnSearch.Size = new System.Drawing.Size(88, 37);
            this.btnSearch.TabIndex = 39;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Animated = true;
            this.txtSearch.AutoRoundedCorners = true;
            this.txtSearch.BorderRadius = 17;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.Parent = this.txtSearch;
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.FocusedState.Parent = this.txtSearch;
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.HoverState.Parent = this.txtSearch;
            this.txtSearch.Location = new System.Drawing.Point(183, 23);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "Search";
            this.txtSearch.SelectedText = "";
            this.txtSearch.ShadowDecoration.Parent = this.txtSearch;
            this.txtSearch.Size = new System.Drawing.Size(266, 36);
            this.txtSearch.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 25);
            this.label1.TabIndex = 37;
            this.label1.Text = "Local License ID :";
            // 
            // ucDrivingLicenseInfo1
            // 
            this.ucDrivingLicenseInfo1.Location = new System.Drawing.Point(19, 87);
            this.ucDrivingLicenseInfo1.Name = "ucDrivingLicenseInfo1";
            this.ucDrivingLicenseInfo1.Size = new System.Drawing.Size(726, 247);
            this.ucDrivingLicenseInfo1.TabIndex = 39;
            // 
            // ucReplacementApplicaiontbasicinfo1
            // 
            this.ucReplacementApplicaiontbasicinfo1.Location = new System.Drawing.Point(14, 331);
            this.ucReplacementApplicaiontbasicinfo1.Name = "ucReplacementApplicaiontbasicinfo1";
            this.ucReplacementApplicaiontbasicinfo1.Size = new System.Drawing.Size(731, 153);
            this.ucReplacementApplicaiontbasicinfo1.TabIndex = 41;
            // 
            // gbReplacement
            // 
            this.gbReplacement.Controls.Add(this.chDamaged);
            this.gbReplacement.Controls.Add(this.chLost);
            this.gbReplacement.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbReplacement.Location = new System.Drawing.Point(575, 9);
            this.gbReplacement.Name = "gbReplacement";
            this.gbReplacement.Size = new System.Drawing.Size(166, 72);
            this.gbReplacement.TabIndex = 48;
            this.gbReplacement.TabStop = false;
            this.gbReplacement.Text = "Replacement For:";
            // 
            // chDamaged
            // 
            this.chDamaged.AutoSize = true;
            this.chDamaged.Location = new System.Drawing.Point(5, 47);
            this.chDamaged.Name = "chDamaged";
            this.chDamaged.Size = new System.Drawing.Size(130, 19);
            this.chDamaged.TabIndex = 1;
            this.chDamaged.Tag = "4";
            this.chDamaged.Text = "Damaged License";
            this.chDamaged.UseVisualStyleBackColor = true;
            this.chDamaged.CheckedChanged += new System.EventHandler(this.chDamaged_CheckedChanged);
            // 
            // chLost
            // 
            this.chLost.AutoSize = true;
            this.chLost.Location = new System.Drawing.Point(6, 22);
            this.chLost.Name = "chLost";
            this.chLost.Size = new System.Drawing.Size(98, 19);
            this.chLost.TabIndex = 0;
            this.chLost.Tag = "3";
            this.chLost.Text = "Lost License";
            this.chLost.UseVisualStyleBackColor = true;
            this.chLost.CheckedChanged += new System.EventHandler(this.chLost_CheckedChanged);
            // 
            // ucFilterLocalLicenseForLostorDamaged
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbReplacement);
            this.Controls.Add(this.ucReplacementApplicaiontbasicinfo1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ucDrivingLicenseInfo1);
            this.Name = "ucFilterLocalLicenseForLostorDamaged";
            this.Size = new System.Drawing.Size(760, 496);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbReplacement.ResumeLayout(false);
            this.gbReplacement.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private ucDrivingLicenseInfo ucDrivingLicenseInfo1;
        private ucReplacementApplicaiontbasicinfo ucReplacementApplicaiontbasicinfo1;
        private System.Windows.Forms.GroupBox gbReplacement;
        private System.Windows.Forms.CheckBox chDamaged;
        private System.Windows.Forms.CheckBox chLost;
    }
}
