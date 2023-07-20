﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingVilla.Data.Data;

#nullable disable

namespace ShoppingVilla.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShoppingVilla.Data.Entities.Models.Dashboard.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModuleId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("menu");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Alias = "users",
                            ModuleId = 1,
                            Name = "Users"
                        },
                        new
                        {
                            Id = 2,
                            Alias = "edit_user",
                            ModuleId = 1,
                            Name = "Edit User"
                        },
                        new
                        {
                            Id = 3,
                            Alias = "roles",
                            ModuleId = 1,
                            Name = "Roles"
                        },
                        new
                        {
                            Id = 4,
                            Alias = "add_role",
                            ModuleId = 1,
                            Name = "Add Role"
                        });
                });

            modelBuilder.Entity("ShoppingVilla.Data.Entities.Models.Dashboard.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("modules");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Alias = "user_settings",
                            IsActive = true,
                            Name = "User Settings"
                        },
                        new
                        {
                            Id = 2,
                            Alias = "masters",
                            IsActive = true,
                            Name = "Masters"
                        });
                });

            modelBuilder.Entity("ShoppingVilla.Data.Entities.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "ADMIN"
                        });
                });

            modelBuilder.Entity("ShoppingVilla.Data.Entities.UserLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("LoginTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LogoutTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("UserId");

                    b.ToTable("userLogins");
                });

            modelBuilder.Entity("ShoppingVilla.Data.Entities.UserRegister", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleName")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("userRegister");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConfirmPassword = "0rp0sI3+yuqj7fHLvG0ZYg==",
                            CreatedDate = new DateTime(2023, 7, 20, 18, 14, 2, 970, DateTimeKind.Local).AddTicks(7341),
                            Email = "",
                            IsActive = true,
                            Mobile = "",
                            Name = "Admin",
                            Password = "0rp0sI3+yuqj7fHLvG0ZYg==",
                            RoleName = "ADMIN",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("ShoppingVilla.Data.Entities.Models.Dashboard.Menu", b =>
                {
                    b.HasOne("ShoppingVilla.Data.Entities.Models.Dashboard.Module", "Module")
                        .WithMany()
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");
                });

            modelBuilder.Entity("ShoppingVilla.Data.Entities.UserLogin", b =>
                {
                    b.HasOne("ShoppingVilla.Data.Entities.UserRegister", "UserRegister")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRegister");
                });

            modelBuilder.Entity("ShoppingVilla.Data.Entities.UserRegister", b =>
                {
                    b.HasOne("ShoppingVilla.Data.Entities.Models.Role", "Role")
                        .WithOne("UserRegister")
                        .HasForeignKey("ShoppingVilla.Data.Entities.UserRegister", "RoleName")
                        .HasPrincipalKey("ShoppingVilla.Data.Entities.Models.Role", "Name")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ShoppingVilla.Data.Entities.Models.Role", b =>
                {
                    b.Navigation("UserRegister");
                });
#pragma warning restore 612, 618
        }
    }
}
