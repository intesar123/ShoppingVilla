using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoppingVilla.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "modules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.Id);
                    table.UniqueConstraint("AK_roles_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_menu_modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userRegister",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRegister", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userRegister_roles_RoleName",
                        column: x => x.RoleName,
                        principalTable: "roles",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userLogins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogoutTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userLogins_userRegister_UserId",
                        column: x => x.UserId,
                        principalTable: "userRegister",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "modules",
                columns: new[] { "Id", "Alias", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, "user_settings", true, "User Settings" },
                    { 2, "masters", true, "Masters" }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ADMIN" },
                    { 2, "USER" }
                });

            migrationBuilder.InsertData(
                table: "menu",
                columns: new[] { "Id", "Alias", "ModuleId", "Name" },
                values: new object[,]
                {
                    { 1, "users", 1, "Users" },
                    { 2, "edit_user", 1, "Edit User" },
                    { 3, "roles", 1, "Roles" },
                    { 4, "add_role", 1, "Add Role" }
                });

            migrationBuilder.InsertData(
                table: "userRegister",
                columns: new[] { "Id", "ConfirmPassword", "CreatedDate", "Email", "IsActive", "Mobile", "Name", "Password", "RoleName", "UserName" },
                values: new object[] { 1, "0rp0sI3+yuqj7fHLvG0ZYg==", new DateTime(2023, 7, 31, 11, 6, 1, 880, DateTimeKind.Local).AddTicks(5036), "", true, "", "Admin", "0rp0sI3+yuqj7fHLvG0ZYg==", "ADMIN", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_menu_ModuleId",
                table: "menu",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_roles_Name",
                table: "roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userLogins_UserId",
                table: "userLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_userRegister_Email",
                table: "userRegister",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userRegister_RoleName",
                table: "userRegister",
                column: "RoleName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userRegister_UserName",
                table: "userRegister",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "menu");

            migrationBuilder.DropTable(
                name: "userLogins");

            migrationBuilder.DropTable(
                name: "modules");

            migrationBuilder.DropTable(
                name: "userRegister");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
