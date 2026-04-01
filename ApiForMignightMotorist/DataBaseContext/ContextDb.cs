using ApiForMignightMotorist.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiForMignightMotorist.DataBaseContext
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions options) : base(options)
        {
        
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Logins> Logins { get; set; }
        public DbSet<Scins> Scins { get; set; }
        public DbSet<UserScins> UserScins { get; set; }

    }
}
