using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoppingVilla.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "modules",
                columns: new[] { "Id", "Alias", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, "user_settings", true, "User Settings" },
                    { 2, "masters", true, "Masters" }
                });

            migrationBuilder.UpdateData(
                table: "userRegister",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 20, 18, 11, 5, 460, DateTimeKind.Local).AddTicks(3916));

            migrationBuilder.InsertData(
                table: "menu",
                columns: new[] { "Id", "Alias", "ModuleId", "Name" },
                values: new object[,]
                {
                    { 1, "users", 1, "Users" },
                    { 2, "edit_user", 1, "Edit User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "modules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "modules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "userRegister",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 19, 22, 17, 54, 729, DateTimeKind.Local).AddTicks(4405));
        }
    }
}
