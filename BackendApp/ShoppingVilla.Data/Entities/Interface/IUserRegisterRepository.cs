using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingVilla.Data.Entities.Interface
{
    public interface IUserRegisterRepository
    {
        Task<IEnumerable<UserRegister>> GetAllAsync();
        Task<UserRegister> GetByIdAsync(int id);
        Task<int> CreateAsync(UserRegister userRegister);
        Task<int> UpdateAsync(UserRegister userRegister);
        Task<int> DeleteAsync(int id);
    }
}
