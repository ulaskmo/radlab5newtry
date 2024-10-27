using Microsoft.EntityFrameworkCore;
using radlab5._1.Models;

namespace radlab5._1.Data
{
    public class FluentUserDbContext : DbContext
    {
        public FluentUserDbContext(DbContextOptions<FluentUserDbContext> options) : base(options) { }

        public DbSet<FluentUser> FluentUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FluentUser>(entity =>
            {
                entity.ToTable("FluentUsers");
                entity.HasKey(u => u.Id);

                entity.Property(u => u.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(u => u.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(u => u.Biography)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(u => u.Age)
                    .HasColumnName("age_of_user")
                    .HasDefaultValue(0)
                    .IsRequired();

                entity.Property(u => u.Title)
                    .HasConversion<string>();
            });
        }
    }
}