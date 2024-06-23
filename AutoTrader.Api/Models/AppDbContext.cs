using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AutoTrader.Api.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
              new IdentityRole { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
              new IdentityRole { Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" });

        }
    }
}
