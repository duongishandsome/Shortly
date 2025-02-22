using Microsoft.EntityFrameworkCore;
using Shortly.Data.Models;

namespace Shortly.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Url> Urls { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
