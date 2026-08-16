using DVLD_BusinessLayer1;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Project.Users
{
    public partial class frmLogin : Form
    {

        public frmLogin()
        {
            InitializeComponent();
        }




        private void StoredPassword(string username, string password)
        {
            string filePath = @"E:\Full Stack Project\PasswordHash\PasswordFile.txt";

            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine(username + ":" + password);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void btnLOGIN_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (ClsUser.IsLoginUserExists(username, password) )
            {
                StoredPassword(username, password);
                ClsUser user = ClsUser.FindbyUserName(username);
                clsGlobal.userID = user.UserID;
                clsGlobal.Username = user.UserName;
                clsGlobal.Password = user.PasswordHash;
                clsGlobal.IsActive = user.IsActive;
                if(clsGlobal.IsActive != true)
                {
                    MessageBox.Show("User is not active. Please contact the administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                frmMainForm main = new frmMainForm();

                this.Hide();

                main.ShowDialog();

                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public  void LoginChecked()
        {
            if (rdRemeberme.Checked)
            {
                string filePath = @"E:\Full Stack Project\PasswordHash\PasswordFile.txt";
                try
                {
                    if (File.Exists(filePath))
                    {
                        string[] lines = File.ReadAllLines(filePath);
                        foreach (string line in lines)
                        {
                            // Assuming the format is "username:password"
                            string[] parts = line.Split(':');
                            if (parts.Length == 2)
                            {
                                txtUsername.Text = parts[0];
                                txtPassword.Text = parts[1];
                                // Do something with the username and password
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }
    }
}
