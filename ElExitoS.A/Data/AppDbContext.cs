using ElExitoS.Models;
using Microsoft.EntityFrameworkCore;

namespace ElExitoS.A_.Data
{
    public class AppDbContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
            { }

        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
