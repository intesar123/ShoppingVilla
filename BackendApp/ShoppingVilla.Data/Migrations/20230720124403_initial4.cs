using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoppingVilla.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "menu",
                columns: new[] { "Id", "Alias", "ModuleId", "Name" },
                values: new object[,]
                {
                    { 3, "roles", 1, "Roles" },
                    { 4, "add_role", 1, "Add Role" }
                });

            migrationBuilder.UpdateData(
                table: "userRegister",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 20, 18, 14, 2, 970, DateTimeKind.Local).AddTicks(7341));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "userRegister",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 20, 18, 11, 5, 460, DateTimeKind.Local).AddTicks(3916));
        }
    }
}
