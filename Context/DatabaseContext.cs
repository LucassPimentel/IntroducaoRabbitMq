using CompraService.Models;
using Microsoft.EntityFrameworkCore;

namespace CompraService.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opts) : base(opts)
        {

        }
        public DbSet<Product> Product { get; set; }
    }
}
