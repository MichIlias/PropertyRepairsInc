using Microsoft.EntityFrameworkCore;
using PropertyRepairsIncConsumerAPI.Models;

namespace PropertyRepairsIncConsumerAPI.Data
{
    public class PropertyRepairsDbContext : DbContext
    {
        public DbSet<House> Houses { get; set; }
        public DbSet<Repair> Repairs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=PropertyRepairsInc;User Id=sa;Password=admin!@#123;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<House>().HasKey(h => h.Id);

            modelBuilder.Entity<Repair>().HasKey(r => r.Id);

            modelBuilder.Entity<Repair>()
                .HasOne(r => r.House)
                .WithMany(h => h.Repairs)
                .HasForeignKey(r => r.HouseId);
        }
    }
}
