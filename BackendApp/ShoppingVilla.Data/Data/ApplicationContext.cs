﻿using Microsoft.EntityFrameworkCore;
using ShoppingVilla.Data.Entities;
using ShoppingVilla.Data.Entities.Models;
using ShoppingVilla.Data.Entities.Models.Dashboard;
using ShoppingVilla.Data.Entities.Models.Dashboard.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingVilla.Data.Data
{
    public class ApplicationContext: DbContext
    {
        #region Account
        public DbSet<UserLogin> userLogins { get; set; }
        public DbSet<UserRegister> userRegister { get; set; }
        public DbSet<Role> roles { get; set; }
        #endregion

        #region Dashboard
        public DbSet<Module> modules { get; set; }
        public DbSet<Menu> menu { get; set; }
        public DbSet<ProductCategory> productCategories { get; set; }
        #endregion
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<UserLogin>(ul =>
            //{
            //    ul.HasNoKey();
            //});

            #region for single unique key
            builder.Entity<UserRegister>(r =>
            {
                r.HasIndex(u=>u.Email).IsUnique();
                r.HasIndex(u => u.UserName).IsUnique();
                r.HasOne(u => u.Role).WithMany(r => r.UserRegister).HasPrincipalKey(r=>r.Name).HasForeignKey(x=>x.RoleName);
            });

            //builder.Entity<UserRegister>().HasOne(x=>x.Role).WithMany(x=>x.Roles).HasForeignKey(x=>x.Email);

            builder.Entity<Role>(r =>
            {
                r.HasIndex(u => u.Name).IsUnique();
                //r.HasOne(u => u.UserRegister).WithOne(u=> u.Role).HasPrincipalKey<Role>(u => u.Name).HasForeignKey<UserRegister>(u=>u.RoleName);
                /// https://gavilan.blog/2019/04/14/entity-framework-core-foreign-key-linked-with-a-non-primary-key/


            });
            #endregion

            #region for multiple unique key
            //builder.Entity<UserRegister>().HasKey(r=> new {r.Id, r.Email,r.UserName});
            #endregion

            #region Data Seed
            builder.Seed();
            #endregion


        }
    }
}
