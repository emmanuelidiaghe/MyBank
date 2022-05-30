using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyBank.Data
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions options) : base(options) { }
        public DbSet<Models.User> User { get; set; }
        public DbSet<Models.Login> Login { get; set; }
    }
}