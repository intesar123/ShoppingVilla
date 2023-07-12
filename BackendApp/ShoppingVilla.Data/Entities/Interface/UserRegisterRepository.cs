using Microsoft.EntityFrameworkCore;
using ShoppingVilla.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingVilla.Data.Entities.Interface
{
    public class UserRegisterRepository : GenericRepository<UserRegister>, IUserRegisterRepository
    {
   
        public UserRegisterRepository(ApplicationContext dbContext): base(dbContext)
        {

        }
        public override async void CreateAsync(UserRegister userRegister)
        {
            _context.Add(userRegister);
        }
        public override async Task<List<UserRegister>> GetAllAsync()
        {
            return await _context.userRegister.ToListAsync();
        }
        public override async Task<UserRegister> GetByIdAsync(int Id)
        {
            return _context.userRegister.Where(x => x.Id == Id).SingleOrDefault();
        }
        public override async void UpdateAsync(UserRegister userRegister)
        {
            _context.Update(userRegister);
        }
        public override async void DeleteAsync(UserRegister userRegister)
        {          
            if(userRegister!=null)
            {
                _context.Remove(userRegister);
            }
        }
    }
}
