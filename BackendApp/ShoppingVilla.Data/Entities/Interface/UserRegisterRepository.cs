using Microsoft.EntityFrameworkCore;
using ShoppingVilla.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingVilla.Data.Entities.Interface
{
    public class UserRegisterRepository : IUserRegisterRepository
    {
        private readonly ApplicationContext _dbContext;

        public UserRegisterRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(UserRegister userRegister)
        {
            _dbContext.Add(userRegister);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserRegister>> GetAll()
        {
            return await _dbContext.userRegister.ToListAsync();
        }

        public async Task<UserRegister> GetById(int id)
        {
            return _dbContext.userRegister.Where(x => x.Id == id).SingleOrDefault();
        }
        public async Task<int> Update(UserRegister userRegister)
        {
            _dbContext.Update(userRegister);
            return _dbContext.SaveChanges();
        }
    }
}
