using Microsoft.EntityFrameworkCore;
using ShoppingVilla.Common;
using ShoppingVilla.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingVilla.Data.Entities.Interface
{
    public class UserRegisterRepository : IUserRegisterRepository
    {

        public readonly ApplicationContext _context;
        public UserRegisterRepository(ApplicationContext dbContext)
        {
            _context = dbContext;
        }
        public  async void CreateAsync(UserRegister userRegister)
        {
            if (userRegister != null)
            {
                userRegister.Password = DataEncrypt.Encrypt(userRegister.Password);
                userRegister.ConfirmPassword = DataEncrypt.Encrypt(userRegister.ConfirmPassword);
            }
            _context.AddAsync(userRegister);
        }
        public  async Task<List<UserRegister>> GetAllAsync()
        {
            var users= await _context.userRegister.ToListAsync();
            users.ForEach(user => { user.Password = DataEncrypt.Decrypt(user.Password); user.ConfirmPassword = DataEncrypt.Decrypt(user.ConfirmPassword); });
            return users;
        }
        public  async Task<UserRegister> GetByIdAsync(int Id)
        {
            var user= _context.userRegister.Where(x => x.Id == Id).SingleOrDefault();
            if(user!=null)
            {
                user.Password = DataEncrypt.Decrypt(user.Password);
                user.ConfirmPassword = DataEncrypt.Decrypt(user.ConfirmPassword);
            }

            return user;
        }
        public  async void UpdateAsync(UserRegister userRegister)
        {
            if(userRegister!=null)
            {
                userRegister.Password = DataEncrypt.Encrypt(userRegister.Password);
                userRegister.ConfirmPassword = DataEncrypt.Encrypt(userRegister.ConfirmPassword);
            }
            _context.Update(userRegister);
        }
        public  async void DeleteAsync(UserRegister userRegister)
        {          
            if(userRegister!=null)
            {
                _context.Remove(userRegister);
            }
        }
    }
}
