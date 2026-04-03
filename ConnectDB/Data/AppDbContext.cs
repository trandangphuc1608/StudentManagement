using Microsoft.EntityFrameworkCore;
using ConnectDB.Models;

namespace ConnectDB.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Bảng hệ thống E-Commerce cốt lõi
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        // Bảng khuyến mãi, đánh giá, thanh toán
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Payment> Payments { get; set; }

        // Biến thể, Tồn kho, Vận chuyển, Log
        public DbSet<Variant> Variants { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ràng buộc Unique
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Promotion>().HasIndex(p => p.Code).IsUnique();
            modelBuilder.Entity<Variant>().HasIndex(v => v.SKU).IsUnique(); // SKU phải là duy nhất

            // Seed data danh mục & sản phẩm mẫu
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Điện thoại", CreatedAt = DateTime.Now },
                new Category { Id = 2, Name = "Laptop", CreatedAt = DateTime.Now }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "iPhone 15 Pro", Description = "Apple A17 Pro", CategoryId = 1, Brand = "Apple", Price = 28990000, CreatedAt = DateTime.Now },
                new Product { Id = 2, Name = "MacBook Air M3", Description = "Apple M3 Chip", CategoryId = 2, Brand = "Apple", Price = 27990000, CreatedAt = DateTime.Now }
            );
        }
    }
}