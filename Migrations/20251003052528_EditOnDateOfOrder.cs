using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class EditOnDateOfOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DeliveryTime",
                table: "Orders",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "DeliveryTime",
                value: new DateOnly(2025, 10, 6));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "DeliveryTime",
                value: new DateOnly(2025, 10, 5));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "DeliveryTime",
                value: new DateOnly(2025, 10, 5));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "DeliveryTime",
                value: new DateOnly(2025, 10, 8));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "DeliveryTime",
                value: new DateOnly(2025, 10, 9));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

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
                column: "DeliveryTime",
                value: new DateTime(2025, 10, 8, 19, 27, 6, 565, DateTimeKind.Utc).AddTicks(2454));
        }
    }
}
