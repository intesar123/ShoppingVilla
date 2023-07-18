using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingVilla.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "userRegister",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 22, 44, 21, 211, DateTimeKind.Local).AddTicks(9787));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "userRegister",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 18, 22, 37, 16, 658, DateTimeKind.Local).AddTicks(8256));
        }
    }
}
