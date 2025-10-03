using Microsoft.EntityFrameworkCore;
using School_ECommerce.Data.Models;

namespace School_ECommerce.Data
{
    public class MyAppDbContext : DbContext
    {

        public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(o => o.Order);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderItems)
                .WithOne(o => o.Product);

            //modelBuilder.Entity<OrderItem>()
            //    .ToTable("OrderItem");

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.CustomerProfile)
                .WithOne(o => o.Customer)
                .HasForeignKey<CustomerProfile>(c => c.CustomerId);

            var products = modelBuilder.Entity<Product>();
            products.Property(p => p.Name).IsRequired();
            products.Property(p => p.Name).HasMaxLength(50);


            /*modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Email = "email1@gmail.com", Password = "pass1" },
                new Customer { Id = 2, Email = "email2@gmail.com", Password = "pass2" },
                new Customer { Id = 3, Email = "email3@gmail.com", Password = "pass3" },
                new Customer { Id = 4, Email = "email4@gmail.com", Password = "pass4" }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, OrderId = Guid.NewGuid(), TotalPrice = 1234.567m, CustomerId = 2 }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Food", Description = "Food category" },
                new Category { Id = 2, Name = "Devices", Description = "Devices category" },
                new Category { Id = 3, Name = "Clothes", Description = "clothes category" },
                new Category { Id = 4, Name = "other", Description = "other category" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Cake", Price = 13m, Amount = 5, CategoryId = 1 },
                new Product { Id = 2, Name = "Iphone", Price = 150m, Amount = 5, CategoryId = 2 },
                new Product { Id = 3, Name = "T-shirt", Price = 20m, Amount = 5, CategoryId = 3 },
                new Product { Id = 4, Name = "another product", Price = 13m, Amount = 5, CategoryId = 4 },
                new Product { Id = 5, Name = "meat", Price = 15m, Amount = 5, CategoryId = 1 }
            );*/


            // Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics", Description = "Gadgets and devices" },
                new Category { Id = 2, Name = "Books", Description = "Fiction, non-fiction and more" },
                new Category { Id = 3, Name = "Clothing", Description = "Men and Women apparel" }
            );

            // Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Email = "1@gmail.com", Password = "123456" },
                new Customer { Id = 2, Email = "2@gmail.com", Password = "123456" },
                new Customer { Id = 3, Email = "3@gmail.com", Password = "123456" },
                new Customer { Id = 4, Email = "4@gmail.com", Password = "123456" }
            );

            // Customer Profiles
            modelBuilder.Entity<CustomerProfile>().HasData(
                new CustomerProfile { Id = 1, Name = "Nour", Address = "Cairo", DateofBirth = new DateOnly(1990, 5, 1), PhoneNumber = "1234567890", CustomerId = 1 },
                new CustomerProfile { Id = 2, Name = "Mohamed", Address = "Giza", DateofBirth = new DateOnly(1985, 10, 12), PhoneNumber = "9876543210", CustomerId = 2 },
                new CustomerProfile { Id = 3, Name = "Saif", Address = "Giza", DateofBirth = new DateOnly(1995, 2, 20), PhoneNumber = "5551234567", CustomerId = 3 },
                new CustomerProfile { Id = 4, Name = "Hussein", Address = "Cairo", DateofBirth = new DateOnly(2000, 10, 8), PhoneNumber = "5551234567", CustomerId = 4 }
            );

            // Products
            modelBuilder.Entity<Product>().HasData(
                // Electronics
                new Product { Id = 1, Name = "Laptop", Price = 999.99m, Amount = 50, CategoryId = 1 },
                new Product { Id = 2, Name = "Smartphone", Price = 599.49m, Amount = 100, CategoryId = 1 },
                new Product { Id = 3, Name = "Headphones", Price = 149.99m, Amount = 200, CategoryId = 1 },

                // Books
                new Product { Id = 4, Name = "C# Programming", Price = 39.99m, Amount = 75, CategoryId = 2 },
                new Product { Id = 5, Name = "ASP.NET Core Guide", Price = 49.99m, Amount = 60, CategoryId = 2 },
                new Product { Id = 6, Name = "Database Design", Price = 29.99m, Amount = 80, CategoryId = 2 },

                // Clothing
                new Product { Id = 7, Name = "T-Shirt", Price = 19.99m, Amount = 150, CategoryId = 3 },
                new Product { Id = 8, Name = "Jeans", Price = 49.99m, Amount = 120, CategoryId = 3 },
                new Product { Id = 9, Name = "Jacket", Price = 89.99m, Amount = 70, CategoryId = 3 }
            );

            // Orders
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, OrderId = Guid.Parse("11111111-1111-1111-1111-111111111111"), CustomerId = 1, TotalPrice = 1649.47m, DeliveryTime = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(3)) },
                new Order { Id = 2, OrderId = Guid.Parse("22222222-2222-2222-2222-222222222222"), CustomerId = 2, TotalPrice = 89.98m, DeliveryTime = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(2)) },
                new Order { Id = 3, OrderId = Guid.Parse("33333333-3333-3333-3333-333333333333"), CustomerId = 3, TotalPrice = 79.98m, DeliveryTime = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(2)) },
                new Order { Id = 4, OrderId = Guid.Parse("44444444-4444-4444-4444-444444444444"), CustomerId = 1, TotalPrice = 139.98m, DeliveryTime = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(5)) },
                new Order { Id = 5, OrderId = Guid.Parse("55555555-5555-5555-5555-555555555555"), CustomerId = 4, TotalPrice = 139.98m, DeliveryTime = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(6)) }
            );

            // Order Items 
            modelBuilder.Entity<OrderItem>().HasData(
                // Order 1 (Customer 1)
                new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Amount = 1, PriceAtOrder = 999.99m },
                new OrderItem { Id = 2, OrderId = 1, ProductId = 2, Amount = 1, PriceAtOrder = 599.49m },
                new OrderItem { Id = 3, OrderId = 1, ProductId = 3, Amount = 1, PriceAtOrder = 49.99m },

                // Order 2 (Customer 2)
                new OrderItem { Id = 4, OrderId = 2, ProductId = 7, Amount = 2, PriceAtOrder = 19.99m },
                new OrderItem { Id = 5, OrderId = 2, ProductId = 8, Amount = 1, PriceAtOrder = 49.99m },

                // Order 3 (Customer 3)
                new OrderItem { Id = 6, OrderId = 3, ProductId = 4, Amount = 2, PriceAtOrder = 39.99m },

                // Order 4 (Customer 1)
                new OrderItem { Id = 7, OrderId = 4, ProductId = 6, Amount = 2, PriceAtOrder = 29.99m },
                new OrderItem { Id = 8, OrderId = 4, ProductId = 9, Amount = 1, PriceAtOrder = 79.99m },

                // Order 5 (Customer 4)
                new OrderItem { Id = 9, OrderId = 5, ProductId = 6, Amount = 2, PriceAtOrder = 29.99m },
                new OrderItem { Id = 10, OrderId = 5, ProductId = 9, Amount = 1, PriceAtOrder = 79.99m }
            );

        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerProfile> CustomerProfiles { get; set; }
    }
}
