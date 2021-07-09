using System.Threading.Tasks;
using G_senger.Models;

namespace G_senger.Data
{
    public interface IServerRepository
    {
        bool Login(User user);

        Task<User> GetUserByIdAsync(int id);

        void CreateUser(User user); // Make it bool

        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task<bool> SaveChangesAsync();

    }
}
