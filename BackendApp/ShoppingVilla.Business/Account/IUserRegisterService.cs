using ShoppingVilla.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingVilla.Business.Account
{
    public interface IUserRegisterService
    {
        Task<int> RegisterAsync(UserRegister userRegister);
        Task<int> UpdateAsync(UserRegister userRegister);
        Task<int> DeleteAsync(int id);
        Task<UserRegister> GetByIdAsync(int id);
        Task<IEnumerable<UserRegister>> GetAllAsync();

    }
}
