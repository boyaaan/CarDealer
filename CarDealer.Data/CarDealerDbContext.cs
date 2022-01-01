namespace CarDealer.Data
{
    using Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    
    public class CarDealerDbContext : IdentityDbContext<User>
    {
        public CarDealerDbContext(DbContextOptions<CarDealerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cars> Car { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Parts> Parts { get; set; }
        public DbSet<PartCars> PartCars { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
               .Entity<PartCars>()
               .HasKey(p => new { p.CarId, p.PartId });

            builder
                .Entity<PartCars>()
                .HasOne(c => c.Car)
                .WithMany(p => p.Parts)
                .HasForeignKey(c => c.CarId);

            builder
                .Entity<PartCars>()
                .HasOne(p => p.Part)
                .WithMany(c => c.Cars)
                .HasForeignKey(c => c.PartId);

            builder.Entity<Sales>()
                .HasOne(c => c.Car)
                .WithMany(s => s.Sales)
                .HasForeignKey(c => c.CarId);

            builder.Entity<Sales>()
                .HasOne(cu => cu.Customer)
                .WithMany(s => s.Sales)
                .HasForeignKey(cu => cu.CustomerId);

            builder.Entity<Suppliers>()
                .HasMany(p => p.Parts)
                .WithOne(s => s.Supplier)
                .HasForeignKey(s => s.SupplierId);

            base.OnModelCreating(builder);
        }
    }
}
