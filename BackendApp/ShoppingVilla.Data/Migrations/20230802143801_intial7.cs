using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingVilla.Data.Migrations
{
    /// <inheritdoc />
    public partial class intial7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "menu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "menu",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "User Settings", 0 });

            migrationBuilder.UpdateData(
                table: "menu",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Alias", "Name", "ParentId" },
                values: new object[] { "users", "Users", 1 });

            migrationBuilder.UpdateData(
                table: "menu",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Alias", "Name", "ParentId" },
                values: new object[] { "edit_user", "Add User", 1 });

            migrationBuilder.UpdateData(
                table: "menu",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Alias", "Name", "ParentId" },
                values: new object[] { "roles", "Roles", 1 });

            migrationBuilder.InsertData(
                table: "menu",
                columns: new[] { "Id", "Alias", "ModuleId", "Name", "ParentId" },
                values: new object[] { 5, "add_role", 1, "Add Role", 1 });

            migrationBuilder.UpdateData(
                table: "userRegister",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 20, 8, 1, 802, DateTimeKind.Local).AddTicks(6214));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "menu",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "menu");

            migrationBuilder.UpdateData(
                table: "menu",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Users");

            migrationBuilder.UpdateData(
                table: "menu",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Alias", "Name" },
                values: new object[] { "edit_user", "Add User" });

            migrationBuilder.UpdateData(
                table: "menu",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Alias", "Name" },
                values: new object[] { "roles", "Roles" });

            migrationBuilder.UpdateData(
                table: "menu",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Alias", "Name" },
                values: new object[] { "add_role", "Add Role" });

            migrationBuilder.UpdateData(
                table: "userRegister",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 31, 23, 42, 7, 671, DateTimeKind.Local).AddTicks(9524));
        }
    }
}
