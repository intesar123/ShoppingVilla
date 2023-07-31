using ShoppingVilla.Data.Entities.Models;
using ShoppingVilla.Data.Entities.Models.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingVilla.Data.Entities.Interface.Dashboard
{
    public interface IMenuRepository
    {
        Task<List<Menu>> GetAllAsync();
        Task<Menu> GetByIdAsync(int id);
        Task<List<Menu>> GetByModuleAsync(int ModuleId);
        void CreateAsync(Menu menu);
        void UpdateAsync(Menu menu);
        void DeleteAsync(int Id);
    }
}
