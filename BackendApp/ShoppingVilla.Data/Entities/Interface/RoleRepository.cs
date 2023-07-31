using Microsoft.EntityFrameworkCore;
using ShoppingVilla.Data.Data;
using ShoppingVilla.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingVilla.Data.Entities.Interface
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationContext _context;

        public RoleRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void CreateAsync(Role role)
        {
            _context.roles.AddAsync(role);
        }

        public void DeleteAsync(int id)
        {
            var role = _context.roles.Where(x=>x.Id==id).FirstOrDefault();
            if(role != null)
            {
                _context.roles.Remove(role);
            }
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await _context.roles.ToListAsync();
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await _context.roles.Where(x=>x.Id==id).FirstOrDefaultAsync();
        }

        public void UpdateAsync(Role role)
        {
            _context.roles.Update(role);
        }
    }
}
