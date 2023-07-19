using ShoppingVilla.Data.Entities.Models;
using ShoppingVilla.Data.Entities.Models.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingVilla.Data.Entities.Interface.Dashboard
{
    public interface IModuleRepository
    {
        Task<List<Module>> GetAllAsync();
        Task<Module> GetByIdAsync(int Id);
        void CreateAsync(Module module);
        void UpdateAsync(Module module);
        void DeleteAsync(int Id);
    }
}
