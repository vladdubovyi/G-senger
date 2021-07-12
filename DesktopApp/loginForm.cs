using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent(); 
        }

        private void loginForm_Load(object sender, EventArgs e)
        {

        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            // Resetting error panel
            panelError.Visible = false;

            // Validation
            var emailValidator = new EmailAddressAttribute();
            if (!emailValidator.IsValid(textBoxEmail.Text))
            {
                MessageBox.Show(this, "You entered inappropriate email!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (String.IsNullOrWhiteSpace(textBoxPass.Text))
            {
                MessageBox.Show(this, "You must fill in password field!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Trying to login to account
            if ( await TryLogin(textBoxEmail.Text, textBoxPass.Text) ) {
                new mainForm().Show();
                this.Hide();
            }
            else
            {
                // Setting error panel
                panelError.Visible = true;
            }
  
        }

        private async Task<bool> TryLogin(string userEmail, string userPass)
        {
            string JsonString = "{'email':'" + userEmail + "','password':'" + userPass + "'}";
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(
                    "http://localhost",
                     new StringContent(JsonString, Encoding.UTF8, "application/json"));
                return response.StatusCode == HttpStatusCode.OK;
            }

        }

        private void loginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            registerForm rf = new registerForm(this);
            rf.Show();
            this.Hide();
        }
    }
}
