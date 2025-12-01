using Microsoft.EntityFrameworkCore;
using ThankYouHashem.Models;

namespace ThankYouHashem.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserProfile> UserProfiles => Set<UserProfile>();
        public DbSet<Order> Orders => Set<Order>();
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // קשר אחד-לאחד
            modelBuilder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<UserProfile>(p => p.UserId);

            // קשר אחד-לרבים
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            // קשר רבים-לרבים
            modelBuilder.Entity<User>()
                .HasMany(u => u.Products)
                .WithMany(p => p.Users)
                .UsingEntity(j => j.ToTable("UserProducts"));

            // קשר אחד-לרבים
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);

            // קשר רבים-לרבים
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Products)
                .WithMany(p => p.Orders)
                .UsingEntity(j => j.ToTable("OrderProducts"));
        }
    }
}

