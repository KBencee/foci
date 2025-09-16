using FociWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FociWebApp.Data
{
    public class FociDbContext : DbContext
    {
        public FociDbContext(DbContextOptions<FociDbContext> options) : base(options)
        {

        }

        public DbSet<Meccs> meccsek {  get; set; }
    }
}
