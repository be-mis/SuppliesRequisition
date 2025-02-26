using Microsoft.EntityFrameworkCore;
using SuppliesRequisition.Model;

namespace SuppliesRequisition.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options){}

        public DbSet<AppUser> AppUsers { get; set; }
    }
}
