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

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public bool CreateUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if(_context.Users.Where(u => u.Email.ToLower() == user.Email.ToLower()).ToArray().Length > 0)
            {
                return false;
            }

            _context.Add(user);
            return true;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        //public async Task UpdateUserAsync(User user)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task DeleteUserAsync(User user)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
