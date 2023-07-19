using Microsoft.EntityFrameworkCore;
using ShoppingVilla.Data.Data;
using ShoppingVilla.Data.Entities.Models.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingVilla.Data.Entities.Interface.Dashboard
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly ApplicationContext _context;

        public ModuleRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async void CreateAsync(Module module)
        {
            await _context.modules.AddAsync(module);
        }

        public void DeleteAsync(int Id)
        {
            var module= _context.modules.Where(x=>x.Id==Id).FirstOrDefault();
            if (module!=null)
            {
                _context.modules.Remove(module);
            }
        }

        public async Task<List<Module>> GetAllAsync()
        {
            return await _context.modules.ToListAsync();
        }

        public async Task<Module> GetByIdAsync(int Id)
        {
            return await _context.modules.FindAsync(Id);
        }

        public void UpdateAsync(Module module)
        {
           _context.Update(module);
        }
    }
}
