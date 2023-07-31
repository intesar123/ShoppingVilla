using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingVilla.Data.Migrations
{
    /// <inheritdoc />
    public partial class Intial6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "userRegister",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 31, 23, 42, 7, 671, DateTimeKind.Local).AddTicks(9524));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "userRegister",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 31, 20, 51, 57, 799, DateTimeKind.Local).AddTicks(4365));
        }
    }
}
