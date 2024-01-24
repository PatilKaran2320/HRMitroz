using Country.Models;
using Microsoft.EntityFrameworkCore;

namespace Country.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<CountryAll> countries { get; set; }
    }
}
