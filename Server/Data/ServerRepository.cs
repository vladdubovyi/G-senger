using G_senger.Contexts;
using G_senger.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

            return (_context.Users.Where(u => u.Email == user.Email && u.Password == user.Password) != null);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public void CreateUser(User user) // Make user uniqueness check
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Add(user);

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
    }
}
