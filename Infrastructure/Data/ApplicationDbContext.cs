using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<Renter> Renters { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Motorcycle>().ToTable("motorcycle", schema: "codech");
            // modelBuilder.Entity<Renter>().ToTable("renter", schema: "codech");

            modelBuilder.Entity<Motorcycle>(entity =>
            {
                entity.ToTable("motorcycle", "codech");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Year).HasColumnName("year");
                entity.Property(e => e.Model).HasColumnName("model");
                entity.Property(e => e.Plate).HasColumnName("plate");
            });

            modelBuilder.Entity<Renter>(entity =>
            {
                entity.ToTable("renter", "codech");
                entity.Property(e => e.Id).HasColumnName("id");
                // Map other properties similarly
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
