using Microsoft.EntityFrameworkCore;
using PcPartsStore.Application.Contracts;
using PcPartsStore.Domain.Common;
using PcPartsStore.Domain.Entities;

namespace PcPartsStore.Persistence
{
    public class PcPartsStoreDbContext : DbContext
    {
        private readonly ILoggedInUserService? _loggedInUserService;

        public PcPartsStoreDbContext(DbContextOptions<PcPartsStoreDbContext> options) : base(options)
        {
        }

        public PcPartsStoreDbContext(DbContextOptions<PcPartsStoreDbContext> options, ILoggedInUserService loggedInUserService) : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        public DbSet<Parts> Parts { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Order> orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Parts>().HasKey(p => p.PartId);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PcPartsStoreDbContext).Assembly);

            //seed data, added through migrations
            var motherboardGuid = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}");
            var cpuGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var gpuGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var ramGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var storageGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = motherboardGuid, CategoryName = "Motherboard" },
                new Category { CategoryId = cpuGuid, CategoryName = "CPU" },
                new Category { CategoryId = gpuGuid, CategoryName = "GPU" },
                new Category { CategoryId = ramGuid, CategoryName = "RAM" },
                new Category { CategoryId = storageGuid, CategoryName = "Storage" }
            );

            modelBuilder.Entity<Parts>().HasData(
                new Parts
                {
                    PartId = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
                    PartName = "ASUS ROG Strix Z490-E Gaming",
                    PartPrice = 299.99m,
                    PartImage = "https://www.asus.com/media/global/products/4vkbvzqyqk7vzv3l/P_setting_000_1_90_end_500.png",
                    PartChipset = "Intel Z490",
                    PartWarranty = "3 years",
                    PartQuantity = "10",
                    CategoryId = motherboardGuid
                }
            );

            modelBuilder.Entity<Parts>().HasData(new Parts
            {
                PartId = Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529319}"),
                PartName = "Intel Core i9-10900K",
                PartPrice = 499.99m,
                PartImage = "https://www.intel.com/content/dam/products/hero/foreground/core-i9-10900k-processor-16m-1-60ghz.png.rendition.intel.web.864.486.png",
                PartChipset = "Intel Z490",
                PartWarranty = "3 years",
                PartQuantity = "10",
                CategoryId = cpuGuid
            });

            modelBuilder.Entity<Parts>().HasData(new Parts
            {
                PartId = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
                PartName = "NVIDIA GeForce RTX 3080",
                PartPrice = 699.99m,
                PartImage = "https://www.nvidia.com/content/dam/en-zz/Solutions/geforce/ampere/rtx-3080/rtx-3080-shop-1.png",
                PartChipset = "NVIDIA Ampere",
                PartWarranty = "3 years",
                PartQuantity = "10",
                CategoryId = gpuGuid
            });

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    OrderId = Guid.Parse("{1BABD057-E980-4CB3-9CD2-7FDD9E525668}"),
                    UserId = Guid.Parse("{ADC42C09-08C1-4D2C-9F96-2D15BB1AF299}"),
                    OrderTotal = 299.99m,
                    OrderPlaced = DateTime.Now,
                    OrderPaid = true
                }
            );
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            if (_loggedInUserService == null)
            {
                return base.SaveChangesAsync(cancellationToken);
            }

            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }

            return base.SaveChangesAsync();
        }
    }
}
