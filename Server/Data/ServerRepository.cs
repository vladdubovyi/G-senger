using G_senger.Contexts;
using G_senger.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace G_senger.Data
{
    public class ServerRepository : IServerRepository
    {
        private readonly UsersContext _context;

        public ServerRepository(UsersContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool Login(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return (_context.Users.Where(u => u.Email == user.Email && u.Password == user.Password).ToArray().Length > 0);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public bool CreateUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if(_context.Users.Where(u => u.Email == user.Email).ToArray().Length > 0)
            {
                return false;
            }

            _context.Add(user);
            return true;
        }

        public async Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public async Task<string> SendMail(string email)
        {
            string _regCode = GenerateCode();

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

            return _regCode;
        }

        private string GenerateCode()
        {
            string symbs = "1234567890qwertyuiopasdjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM<>?{}:";

            return new string(Enumerable.Repeat(symbs, 8)
                  .Select(s => s[new Random().Next(s.Length)]).ToArray());
        }
    }
}
