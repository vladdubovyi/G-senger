using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class registerForm : Form
    {
        private readonly loginForm _lf;
        private string _regCode;

        public registerForm(loginForm lf)
        {
            _lf = lf;
            InitializeComponent();
        }

        private void registerForm_Load(object sender, EventArgs e)
        {

        }

        private async void buttonSingUp_Click(object sender, EventArgs e)
        {
            // Validation
            var emailValidator = new EmailAddressAttribute();
            if (!emailValidator.IsValid(textBoxEmail.Text))
            {
                MessageBox.Show(this, "You entered inappropriate email!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (String.IsNullOrWhiteSpace(textBoxPasswd.Text))
            {
                MessageBox.Show(this, "You must write your password!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mail code validation
            await SendMail(textBoxEmail.Text);

            if (new mailCodeCheck(_regCode).ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show(this, "Code does not match the code from mail", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // User creation
            if ( await CreateAccount(textBoxEmail.Text, textBoxPasswd.Text,
                textBoxFirstName.Text, textBoxLastName.Text) )
            {
                MessageBox.Show(this, "Account has been successfully created!", "Success!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "User already exists", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> CreateAccount(string email, string passwd, string firstName, string lastName)
        {
            string JsonString = "{'email':'" + email + 
                                "','password':'" + passwd + 
                                "','firstName':'" + firstName +
                                "','lastName':'" + lastName + "'}";
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(
                    "http://localhost:60208/api/Users",
                     new StringContent(JsonString, Encoding.UTF8, "application/json"));
                return response.StatusCode == HttpStatusCode.Created;
            }
        }

        private async Task SendMail(string email)
        {
            _regCode = GenerateCode();

            MailAddress from = new MailAddress("vovkamorkovka435@gmail.com", "G-senger");
            MailAddress to = new MailAddress(email);

            MailMessage message = new MailMessage(from, to);

            message.Subject = "User registration";
            message.Body = $"<h2>Welcome to G-senger! We are glad to see you :) Your code is: {_regCode}<h2>";
            message.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("vovkamorkovka435@gmail.com", "");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(message);
        }

        private string GenerateCode()
        {
            string symbs = "1234567890qwertyuiopasdjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM<>?{}:";

            return new string(Enumerable.Repeat(symbs, 8)
                  .Select(s => s[new Random().Next(s.Length)]).ToArray());
        }

        private void registerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _lf.Show();
        }
    }
}
