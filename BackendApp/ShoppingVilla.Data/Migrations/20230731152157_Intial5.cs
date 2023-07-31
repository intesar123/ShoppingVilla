using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingVilla.Data.Migrations
{
    /// <inheritdoc />
    public partial class Intial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "menu",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Add User");

            migrationBuilder.UpdateData(
                table: "userRegister",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 31, 20, 51, 57, 799, DateTimeKind.Local).AddTicks(4365));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "menu",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Edit User");

            migrationBuilder.UpdateData(
                table: "userRegister",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 31, 18, 3, 41, 297, DateTimeKind.Local).AddTicks(4871));
        }
    }
}
