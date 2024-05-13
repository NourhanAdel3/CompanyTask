using Microsoft.EntityFrameworkCore;

namespace CompanyTask.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
        }

        public DbSet<User> users { get; set; }
        public DbSet<Address> addresses { get; set; }
    }
}
