using Microsoft.EntityFrameworkCore.Internal;
using ShoppingVilla.Data.Entities;
using ShoppingVilla.Data.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingVilla.Business.Account
{
    public class UserRegisterService : IUserRegisterService
    {
        private readonly IUserRegisterRepository _repository;
        public UserRegisterService(IUserRegisterRepository repository)
        {
            _repository = repository;
        }
        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserRegister> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> RegisterAsync(UserRegister userRegister)
        {
            return _repository.Create(userRegister);
        }

        public Task<int> UpdateAsync(UserRegister userRegister)
        {
            throw new NotImplementedException();
        }
    }
}
