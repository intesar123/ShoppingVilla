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
            builder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                Name = "ADMIN"
            });

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
                new Module { Id=1, Name="User Settings", Alias="user_settings", IsActive=true },
                new Module { Id=2, Name="Masters", Alias="masters", IsActive=true}
                );

            builder.Entity<Menu>().HasData(
                new Menu { Id=1,Name="Users", Alias="users",ModuleId=1},
                new Menu { Id = 2, Name = "Edit User", Alias="edit_user", ModuleId = 1 },
                new Menu { Id = 3, Name = "Roles", Alias = "roles", ModuleId = 1 },
                new Menu { Id = 4, Name = "Add Role", Alias = "add_role", ModuleId = 1 }
                );
        } 
    }
}
