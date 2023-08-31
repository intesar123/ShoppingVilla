using Microsoft.EntityFrameworkCore;
using ShoppingVilla.Data.Entities.Models;
using ShoppingVilla.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingVilla.Data.Entities.Models.Dashboard;

namespace ShoppingVilla.Data.Data
{
    public static class ModelBuilderExtention
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "ADMIN"
                },
                new Role
                {
                    Id = 2,
                    Name = "USER"
                }
                );

            builder.Entity<UserRegister>().HasData(new UserRegister
            {
                Id = 1,
                Name = "Admin",
                UserName = "admin",
                Email = "",
                Password = "0rp0sI3+yuqj7fHLvG0ZYg==",
                ConfirmPassword = "0rp0sI3+yuqj7fHLvG0ZYg==",
                Mobile = "",
                RoleName = "ADMIN"
            });

            builder.Entity<Module>().HasData(
                new Module { Id = 1, Name = "User Settings", Alias = "user_settings", IsActive = true },
                new Module { Id = 2, Name = "Masters", Alias = "masters", IsActive = true }
                );

            builder.Entity<Menu>().HasData(
                new Menu { Id = 1, Name = "User Settings", Alias = "users", ModuleId = 1, ParentId=0 },
                new Menu { Id = 2, Name = "Users", Alias = "users", ModuleId = 1 , ParentId = 1 },
                new Menu { Id = 3, Name = "Add User", Alias = " ", ModuleId = 1 , ParentId = 1 },
                new Menu { Id = 4, Name = "Roles", Alias = "roles", ModuleId = 1 , ParentId = 1 },
                new Menu { Id = 5, Name = "Add Role", Alias = "add_role", ModuleId = 1 ,ParentId = 1 },
                new Menu { Id = 6, Name = "Menus", Alias = "menus", ModuleId = 1, ParentId = 0 },
                new Menu { Id = 7, Name = "Menu Setting", Alias = "menus", ModuleId = 1, ParentId = 6 },

                new Menu { Id = 8, Name = "Products", Alias = "menus", ModuleId = 2, ParentId = 0 },
                new Menu { Id = 9, Name = "Product Categories", Alias = "product_categories", ModuleId = 2, ParentId = 8 },
                new Menu { Id = 10, Name = "Add Product Categories", Alias = "add_product_category", ModuleId = 2, ParentId = 8 }
                );

        }
    }
}
