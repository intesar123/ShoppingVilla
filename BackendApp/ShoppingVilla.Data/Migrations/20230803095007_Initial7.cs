using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoppingVilla.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "menu",
                columns: new[] { "Id", "Alias", "ModuleId", "Name", "ParentId" },
                values: new object[,]
                {
                    { 6, "menus", 1, "Menus", 0 },
                    { 7, "menus", 1, "Menu Setting", 6 }
                });

            migrationBuilder.UpdateData(
                table: "userRegister",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 3, 15, 20, 7, 12, DateTimeKind.Local).AddTicks(5143));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "userRegister",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 20, 8, 1, 802, DateTimeKind.Local).AddTicks(6214));
        }
    }
}
