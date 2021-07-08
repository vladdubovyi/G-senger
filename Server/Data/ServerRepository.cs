using G_senger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G_senger.Data
{
    public class ServerRepository : IServerRepository
    {
        public void CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Login()
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
