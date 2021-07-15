using G_senger.Models;
using System.Threading.Tasks;

namespace G_senger.Data
{
    public interface IAuthRepository
    {
        bool Login(User user);
        bool RegisterUser(User user);
        Task<string> SendMail(string email);

        Task<bool> SaveChangesAsync();
    }
}
