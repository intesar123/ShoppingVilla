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

        public async Task<int> CreateAsync(UserRegister userRegister)
        {
            _dbContext.Add(userRegister);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserRegister>> GetAllAsync()
        {
            return await _dbContext.userRegister.ToListAsync();
        }

        public async Task<UserRegister> GetByIdAsync(int Id)
        {
            return _dbContext.userRegister.Where(x => x.Id == Id).SingleOrDefault();
        }
        public async Task<int> UpdateAsync(UserRegister userRegister)
        {
            _dbContext.Update(userRegister);
            return _dbContext.SaveChanges();
        }
        public async Task<int> DeleteAsync(int Id)
        {
            var user = await _dbContext.userRegister.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if(user != null)
            {
                _dbContext.Remove(user);
                return _dbContext.SaveChanges();
            }
            else { return 0; }
        }
    }
}
