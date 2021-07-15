using G_senger.Configuration;
using G_senger.Contexts;
using G_senger.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace G_senger.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UsersContext _context;
        private readonly EmailConfig _emailConfig;

        public AuthRepository(UsersContext context, IOptionsMonitor<EmailConfig> optionsMonitor)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _emailConfig = optionsMonitor.CurrentValue ?? throw new ArgumentNullException(nameof(optionsMonitor));
        }

        public bool RegisterUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (_context.Users.Where(u => u.Email.ToLower() == user.Email.ToLower()).ToArray().Length > 0)
            {
                return false;
            }

            _context.Add(user);
            return true;
        }

        public bool Login(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return (_context.Users.Where(u => u.Email.ToLower() == user.Email.ToLower() && u.Password == user.Password).ToArray().Length > 0);
        }

        public async Task<string> SendMail(string email)
        {
            Console.WriteLine($"{_emailConfig.EmailAddress} {_emailConfig.Password}");
            string _regCode = GenerateCode();

            MailAddress from = new MailAddress(_emailConfig.EmailAddress, "G-senger");
            MailAddress to = new MailAddress(email);

            MailMessage message = new MailMessage(from, to);

            message.Subject = "User registration";
            message.Body = $"<h2>Welcome to G-senger! We are glad to see you :) Your code is: {_regCode}<h2>";
            message.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(_emailConfig.EmailAddress, _emailConfig.Password);
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(message);

            return _regCode;
        }

        private string GenerateCode()
        {
            string symbs = "1234567890qwertyuiopasdjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM<>?{}:";

            return new string(Enumerable.Repeat(symbs, 8)
                  .Select(s => s[new Random().Next(s.Length)]).ToArray());
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
