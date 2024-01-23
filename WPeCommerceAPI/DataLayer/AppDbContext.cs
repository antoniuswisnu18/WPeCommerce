using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WPeCommerceAPI.DataLayer.Models;

namespace WPeCommerceAPI.DataLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<ChartItem> ChartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.ToTable("Product");
                entity.Property(e => e.Name)
                    .HasMaxLength(225)
                    .IsUnicode(false);
                entity.Property(e => e.Price).HasColumnType("money");
                entity.HasMany(p => p.Reviews)
                .WithOne(r => r.Product)
                .HasForeignKey(r => r.ProductId);
                entity.HasMany(p => p.ChartItems)
                .WithOne(c => c.Product)
                .HasForeignKey(c => c.ProductId);
            });


            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.ToTable("User");
                entity.HasMany(u => u.Reviews)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.ToTable("Review");         
            });

            modelBuilder.Entity<ChartItem>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.ToTable("ChartItem");
            });

        }
    }
}
