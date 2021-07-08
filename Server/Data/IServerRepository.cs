using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G_senger.Models;

namespace G_senger.Data
{
    interface IServerRepository
    {
        Task<bool> Login();

        Task<User> GetUserById(Guid id);

        void CreateUser(User user);

        Task UpdateUser(Guid id);
        Task DeleteUser(Guid id);

    }
}
