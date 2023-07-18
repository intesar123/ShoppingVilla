using ShoppingVilla.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingVilla.Data.Entities.Interface
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllAsync();
        Task<Role> GetByIdAsync(int id);
        void CreateAsync(Role role);
        void UpdateAsync(Role role);
        void DeleteAsync(Role role);
    }
}
