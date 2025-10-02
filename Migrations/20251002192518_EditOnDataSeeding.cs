using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace School_ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class EditOnDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CustomerProfiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Name" },
                values: new object[] { "Cairo", "Nour" });

            migrationBuilder.UpdateData(
                table: "CustomerProfiles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Name" },
                values: new object[] { "Giza", "Mohamed" });

            migrationBuilder.UpdateData(
                table: "CustomerProfiles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "Name" },
                values: new object[] { "Giza", "Saif" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "1@gmail.com");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "2@gmail.com");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Email",
                value: "3@gmail.com");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Password" },
                values: new object[] { 4, "4@gmail.com", "123456" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "DeliveryTime",
                value: new DateTime(2025, 10, 5, 19, 25, 18, 379, DateTimeKind.Utc).AddTicks(2241));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "DeliveryTime",
                value: new DateTime(2025, 10, 4, 19, 25, 18, 379, DateTimeKind.Utc).AddTicks(2248));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "DeliveryTime",
                value: new DateTime(2025, 10, 4, 19, 25, 18, 379, DateTimeKind.Utc).AddTicks(2260));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "DeliveryTime",
                value: new DateTime(2025, 10, 7, 19, 25, 18, 379, DateTimeKind.Utc).AddTicks(2264));

            migrationBuilder.InsertData(
                table: "CustomerProfiles",
                columns: new[] { "Id", "Address", "CustomerId", "DateofBirth", "Name", "PhoneNumber" },
                values: new object[] { 4, "Cairo", 4, new DateOnly(2000, 10, 8), "Hussein", "5551234567" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "DeliveryTime", "OrderId", "TotalPrice" },
                values: new object[] { 5, 4, new DateTime(2025, 10, 8, 19, 25, 18, 379, DateTimeKind.Utc).AddTicks(2267), new Guid("44444444-4444-4444-4444-444444444444"), 139.98m });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "Amount", "OrderId", "PriceAtOrder", "ProductId" },
                values: new object[,]
                {
                    { 9, 2, 5, 29.99m, 6 },
                    { 10, 1, 5, 79.99m, 9 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerProfiles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "CustomerProfiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Name" },
                values: new object[] { "123 Main St", "Alice" });

            migrationBuilder.UpdateData(
                table: "CustomerProfiles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Name" },
                values: new object[] { "456 Oak Ave", "Bob" });

            migrationBuilder.UpdateData(
                table: "CustomerProfiles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "Name" },
                values: new object[] { "789 Pine Rd", "Charlie" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "alice@example.com");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "bob@example.com");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Email",
                value: "charlie@example.com");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "DeliveryTime",
                value: new DateTime(2025, 10, 4, 20, 26, 41, 16, DateTimeKind.Utc).AddTicks(5165));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "DeliveryTime",
                value: new DateTime(2025, 10, 3, 20, 26, 41, 16, DateTimeKind.Utc).AddTicks(5171));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "DeliveryTime",
                value: new DateTime(2025, 10, 3, 20, 26, 41, 16, DateTimeKind.Utc).AddTicks(5178));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "DeliveryTime",
                value: new DateTime(2025, 10, 6, 20, 26, 41, 16, DateTimeKind.Utc).AddTicks(5182));
        }
    }
}
