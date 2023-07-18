using Microsoft.IdentityModel.Tokens;
using ShoppingVilla.Common;
using ShoppingVilla.Data.Data;
using ShoppingVilla.Data.Utilies;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingVilla.Data.Entities.Interface
{
    public class UserLoginRepository :IUserLoginRepository
    {
        public readonly ApplicationContext _context;
        public UserLoginRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Task<UserLogin> Get(int id)
        {
            throw new NotImplementedException();
        }

        public  Task<string> Login(UserLogin userLogin)
        {
            var user = _context.userRegister.Where(x=>x.UserName == userLogin.UserName && x.Password==DataEncrypt.Encrypt(userLogin.Password)).FirstOrDefault();
            if(user == null)
            {
                 return Task.Run(() =>string.Empty);
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtUtility.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.RoleName),
                    new Claim(ClaimTypes.GivenName, user.Name),
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),

                }),

                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
             
            return  Task.Run(() => tokenHandler.WriteToken(token));
         }

        public Task<int> Logout(string token)
        {
            throw new NotImplementedException();
        }
    }
}
