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
       
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {

        }

        public DbSet<UserLogin> userLogins;
        public DbSet<UserRegister> userRegister;
    }
}
