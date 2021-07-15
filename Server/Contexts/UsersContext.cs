using G_senger.Models;
using Microsoft.EntityFrameworkCore;

namespace G_senger.Contexts
{
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Contacts> Contacts { get; set; }

        public DbSet<Message> Messages { get; set; }

        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
