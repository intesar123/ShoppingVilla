using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingVilla.Data.Migrations
{
    /// <inheritdoc />
    public partial class Intial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userRegister_roles_RoleName",
                table: "userRegister");

            migrationBuilder.DropIndex(
                name: "IX_userRegister_RoleName",
                table: "userRegister");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_roles_Name",
                table: "roles");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_userRegister_RoleName",
                table: "userRegister",
                column: "RoleName");

            migrationBuilder.UpdateData(
                table: "userRegister",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 31, 17, 50, 34, 432, DateTimeKind.Local).AddTicks(9593));

            migrationBuilder.AddForeignKey(
                name: "FK_roles_userRegister_Name",
                table: "roles",
                column: "Name",
                principalTable: "userRegister",
                principalColumn: "RoleName",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roles_userRegister_Name",
                table: "roles");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_userRegister_RoleName",
                table: "userRegister");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_roles_Name",
                table: "roles",
                column: "Name");

            migrationBuilder.UpdateData(
                table: "userRegister",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 31, 13, 51, 5, 386, DateTimeKind.Local).AddTicks(676));

            migrationBuilder.CreateIndex(
                name: "IX_userRegister_RoleName",
                table: "userRegister",
                column: "RoleName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_userRegister_roles_RoleName",
                table: "userRegister",
                column: "RoleName",
                principalTable: "roles",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
