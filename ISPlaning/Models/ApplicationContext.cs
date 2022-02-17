using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ISPlaning.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Goal> Goals { get; set; }
        public DbSet<Wish> Wishes { get; set; }
        public DbSet<Funds> Funds { get; set; }
        public DbSet<Chart> Charts { get; set; }

    }
}
