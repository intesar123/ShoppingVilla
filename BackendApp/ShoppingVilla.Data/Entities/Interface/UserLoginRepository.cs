using ShoppingVilla.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingVilla.Data.Entities.Interface
{
    public class UserLoginRepository : IUserLoginRepository
    {
        private readonly ApplicationContext _dbContext;

        public UserLoginRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(UserLogin userLogin)
        {
            _dbContext.Add(userLogin);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<UserLogin> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserLogin>> GetAll()
        {
            return _dbContext.userLogins.ToList();
        }

        public async Task<IEnumerable<UserLogin>> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<UserLogin>> GetByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(UserLogin userLogin)
        {
            _dbContext.Update(userLogin);
            return _dbContext.SaveChangesAsync();
        }
    }
}
