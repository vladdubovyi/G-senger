using System.Collections.Generic;
using System.Threading.Tasks;
using G_senger.Models;

namespace G_senger.Data
{
    public interface IServerRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task<List<User>> GetContactsByEmailAsync(string email);

        bool CreateUser(User user);

        //Task UpdateUserAsync(User user);
        //Task DeleteUserAsync(User user);
        Task<bool> SaveChangesAsync();
    }
}
