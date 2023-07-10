using Microsoft.EntityFrameworkCore;
using ShoppingVilla.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingVilla.Data.Data
{
    public class ApplicationContext: DbContext
    {
        public DbSet<UserLogin> userLogins { get; set; }
        public DbSet<UserRegister> userRegister { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserLogin>(ul =>
            {
                ul.HasNoKey();
            });
        }
    }
}
