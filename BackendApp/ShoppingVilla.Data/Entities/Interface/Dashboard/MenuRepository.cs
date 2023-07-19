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
    public class MenuRepository : IMenuRepository
    {
        private readonly ApplicationContext _context;
        public MenuRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void CreateAsync(Menu menu)
        {
            _context.menu.Add(menu);
        }

        public void DeleteAsync(int Id)
        {
             var menu = _context.menu.Where(x => x.Id == Id).FirstOrDefault();
            if (menu != null)
            {
                _context.menu.Remove(menu);
            }
        }

        public async Task<List<Menu>> GetAllAsync()
        {
            return await _context.menu.ToListAsync();
        }

        public async Task<Menu> GetByIdAsync(int id)
        {
            return await _context.menu.FindAsync(id);
        }

        public void UpdateAsync(Menu menu)
        {
            _context.Update(menu);
        }
    }
}
