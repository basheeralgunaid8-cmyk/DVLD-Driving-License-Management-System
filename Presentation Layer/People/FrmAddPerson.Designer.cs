namespace Project.People
{
    partial class FrmAddPerson
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
            this.components = new System.ComponentModel.Container();
            this.guna2ColorTransition1 = new Guna.UI2.WinForms.Guna2ColorTransition(this.components);
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblPersonID = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.personDetail1 = new Project.People.PersonDetail();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // guna2ColorTransition1
            // 
            this.guna2ColorTransition1.AutoTransition = true;
            this.guna2ColorTransition1.ColorArray = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.Blue,
        System.Drawing.Color.Orange};
            this.guna2ColorTransition1.EndColor = System.Drawing.Color.White;
            this.guna2ColorTransition1.StartColor = System.Drawing.SystemColors.ActiveCaption;
            // 
            // lblTitle
            // 
            this.lblTitle.AvoidGeometryAntialias = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(284, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 35);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Add New Person";
            this.lblTitle.UseGdiPlusTextRendering = true;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AvoidGeometryAntialias = true;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(12, 20);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(76, 25);
            this.guna2HtmlLabel1.TabIndex = 2;
            this.guna2HtmlLabel1.Text = "PersonID:";
            this.guna2HtmlLabel1.UseGdiPlusTextRendering = true;
            // 
            // lblPersonID
            // 
            this.lblPersonID.AvoidGeometryAntialias = true;
            this.lblPersonID.BackColor = System.Drawing.Color.Transparent;
            this.lblPersonID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPersonID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonID.ForeColor = System.Drawing.Color.Black;
            this.lblPersonID.Location = new System.Drawing.Point(95, 20);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(79, 25);
            this.lblPersonID.TabIndex = 3;
            this.lblPersonID.Text = "_________";
            this.lblPersonID.UseGdiPlusTextRendering = true;
            // 
            // personDetail1
            // 
            this.personDetail1.BackColor = System.Drawing.Color.White;
            this.personDetail1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.personDetail1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.personDetail1.ForeColor = System.Drawing.Color.White;
            this.personDetail1.Location = new System.Drawing.Point(0, 91);
            this.personDetail1.Margin = new System.Windows.Forms.Padding(4);
            this.personDetail1.Name = "personDetail1";
            this.personDetail1.Size = new System.Drawing.Size(754, 343);
            this.personDetail1.TabIndex = 4;
            this.personDetail1.Load += new System.EventHandler(this.personDetail1_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(571, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 5;
            // 
            // FrmAddPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(754, 434);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPersonID);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.personDetail1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAddPerson";
            this.Text = "Add New Person ";
            this.Load += new System.EventHandler(this.FrmAddPerson_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ColorTransition guna2ColorTransition1;
        private PersonDetail personDetail1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPersonID;
        private System.Windows.Forms.Label label1;
    }
}