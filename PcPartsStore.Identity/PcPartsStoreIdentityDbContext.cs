using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PcPartsStore.Identity.Models;

namespace PcPartsStore.Identity
{
    public class PcPartsStoreIdentityDbContext : IdentityDbContext<AppUser>
    {
        public PcPartsStoreIdentityDbContext()
        {
        }

        public PcPartsStoreIdentityDbContext(DbContextOptions<PcPartsStoreIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER" }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
