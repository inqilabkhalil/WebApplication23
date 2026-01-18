using Microsoft.EntityFrameworkCore;
using WebApplication23.Models;

namespace WebApplication23.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Worker> Worker { get; set; }

    }
}
