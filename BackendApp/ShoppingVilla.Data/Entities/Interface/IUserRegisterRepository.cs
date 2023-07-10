using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingVilla.Data.Entities.Interface
{
    public interface IUserRegisterRepository
    {
        Task<IEnumerable<UserRegister>> GetAll();
        Task<UserRegister> GetById(int id);
        Task<int> Create(UserRegister userRegister);
        Task<int> Update(UserRegister userRegister);
    }
}
