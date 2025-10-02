using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class EditOnDataSeeding2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "DeliveryTime",
                value: new DateTime(2025, 10, 5, 19, 27, 6, 565, DateTimeKind.Utc).AddTicks(2436));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "DeliveryTime",
                value: new DateTime(2025, 10, 4, 19, 27, 6, 565, DateTimeKind.Utc).AddTicks(2442));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "DeliveryTime",
                value: new DateTime(2025, 10, 4, 19, 27, 6, 565, DateTimeKind.Utc).AddTicks(2447));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "DeliveryTime",
                value: new DateTime(2025, 10, 7, 19, 27, 6, 565, DateTimeKind.Utc).AddTicks(2450));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DeliveryTime", "OrderId" },
                values: new object[] { new DateTime(2025, 10, 8, 19, 27, 6, 565, DateTimeKind.Utc).AddTicks(2454), new Guid("55555555-5555-5555-5555-555555555555") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DeliveryTime", "OrderId" },
                values: new object[] { new DateTime(2025, 10, 8, 19, 25, 18, 379, DateTimeKind.Utc).AddTicks(2267), new Guid("44444444-4444-4444-4444-444444444444") });
        }
    }
}
