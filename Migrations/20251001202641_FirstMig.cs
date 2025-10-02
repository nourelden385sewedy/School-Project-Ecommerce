using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace School_ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class FirstMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,3)", precision: 8, scale: 3, nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateofBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerProfiles_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(8,3)", precision: 8, scale: 3, nullable: false),
                    DeliveryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceAtOrder = table.Column<decimal>(type: "decimal(8,3)", precision: 8, scale: 3, nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Gadgets and devices", "Electronics" },
                    { 2, "Fiction, non-fiction and more", "Books" },
                    { 3, "Men and Women apparel", "Clothing" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Password" },
                values: new object[,]
                {
                    { 1, "alice@example.com", "123456" },
                    { 2, "bob@example.com", "123456" },
                    { 3, "charlie@example.com", "123456" }
                });

            migrationBuilder.InsertData(
                table: "CustomerProfiles",
                columns: new[] { "Id", "Address", "CustomerId", "DateofBirth", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Main St", 1, new DateOnly(1990, 5, 1), "Alice", "1234567890" },
                    { 2, "456 Oak Ave", 2, new DateOnly(1985, 10, 12), "Bob", "9876543210" },
                    { 3, "789 Pine Rd", 3, new DateOnly(1995, 2, 20), "Charlie", "5551234567" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "DeliveryTime", "OrderId", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 10, 4, 20, 26, 41, 16, DateTimeKind.Utc).AddTicks(5165), new Guid("11111111-1111-1111-1111-111111111111"), 1649.47m },
                    { 2, 2, new DateTime(2025, 10, 3, 20, 26, 41, 16, DateTimeKind.Utc).AddTicks(5171), new Guid("22222222-2222-2222-2222-222222222222"), 89.98m },
                    { 3, 3, new DateTime(2025, 10, 3, 20, 26, 41, 16, DateTimeKind.Utc).AddTicks(5178), new Guid("33333333-3333-3333-3333-333333333333"), 79.98m },
                    { 4, 1, new DateTime(2025, 10, 6, 20, 26, 41, 16, DateTimeKind.Utc).AddTicks(5182), new Guid("44444444-4444-4444-4444-444444444444"), 139.98m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Amount", "CategoryId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 50, 1, "Laptop", 999.99m },
                    { 2, 100, 1, "Smartphone", 599.49m },
                    { 3, 200, 1, "Headphones", 149.99m },
                    { 4, 75, 2, "C# Programming", 39.99m },
                    { 5, 60, 2, "ASP.NET Core Guide", 49.99m },
                    { 6, 80, 2, "Database Design", 29.99m },
                    { 7, 150, 3, "T-Shirt", 19.99m },
                    { 8, 120, 3, "Jeans", 49.99m },
                    { 9, 70, 3, "Jacket", 89.99m }
                });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "Amount", "OrderId", "PriceAtOrder", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, 1, 999.99m, 1 },
                    { 2, 1, 1, 599.49m, 2 },
                    { 3, 1, 1, 49.99m, 3 },
                    { 4, 2, 2, 19.99m, 7 },
                    { 5, 1, 2, 49.99m, 8 },
                    { 6, 2, 3, 39.99m, 4 },
                    { 7, 2, 4, 29.99m, 6 },
                    { 8, 1, 4, 79.99m, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProfiles_CustomerId",
                table: "CustomerProfiles",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerProfiles");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
