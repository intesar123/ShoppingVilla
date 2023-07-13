using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingVilla.Data.Entities.Interface
{
    public interface IUserLoginRepository
    {
        Task<IEnumerable<UserLogin>> GetAll();
        Task<UserLogin> Get(int id);
        Task<IEnumerable<UserLogin>> GetByUserName(string userName);
        Task<string> Login(UserLogin userLogin);
        Task<int> Logout(string token);
    }
}
