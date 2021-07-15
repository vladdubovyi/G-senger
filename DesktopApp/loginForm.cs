using DesktopApp.Dtos;
using DesktopApp.Dtos.Responses;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Text;
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
            var token = await TryLogin(textBoxEmail.Text, textBoxPass.Text);

            if (token != null) {
                new mainForm(token, new User { Email = textBoxEmail.Text , Password = textBoxPass.Text }).Show();
                this.Hide();
            }
            else
            {
                // Setting error panel
                panelError.Visible = true;
            }
  
        }

        private async Task<string> TryLogin(string userEmail, string userPass)
        {
            string JsonString = "{'email':'" + userEmail + "','password':'" + userPass + "'}";
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(
                    "http://localhost:60208/api/Auth/Login",
                     new StringContent(JsonString, Encoding.UTF8, "application/json"));

                var responseJsonString = await response.Content.ReadAsStringAsync();
                var authResponse = JsonConvert.DeserializeObject<AuthResponse>(responseJsonString);

                if ( authResponse.Success == true )
                {
                    return authResponse.Token;
                }

                return null;
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
