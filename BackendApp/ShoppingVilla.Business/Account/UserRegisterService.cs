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
        public async Task<int> DeleteAsync(int Id)
        {
            return await _repository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<UserRegister>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<UserRegister> GetByIdAsync(int Id)
        {
           return await _repository.GetByIdAsync(Id);
        }

        public async Task<int> RegisterAsync(UserRegister userRegister)
        {
            return await _repository.CreateAsync(userRegister);
        }

        public async Task<int> UpdateAsync(UserRegister userRegister)
        {
            return await _repository.UpdateAsync(userRegister);
        }
    }
}
