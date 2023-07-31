using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingVilla.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "userRegister",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 31, 11, 7, 52, 174, DateTimeKind.Local).AddTicks(742));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "userRegister",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 31, 11, 6, 1, 880, DateTimeKind.Local).AddTicks(5036));
        }
    }
}
