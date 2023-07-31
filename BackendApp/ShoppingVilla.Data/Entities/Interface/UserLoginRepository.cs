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

        public  Task<UserLogin> Login(UserLogin userLogin)
        {
            var user = _context.userRegister.Where(x=>x.UserName == userLogin.UserName && x.Password==DataEncrypt.Encrypt(userLogin.Password) && x.IsActive==true).FirstOrDefault();
            if(user == null)
            {
                 return Task.Run(() => new UserLogin());
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

                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            userLogin.Token = tokenHandler.WriteToken(token);
            userLogin.UserId = user.Id;
            userLogin.LoginTime = DateTime.UtcNow;
            userLogin.Password = "";
            _context.userLogins.Add(userLogin);
            return  Task.Run(() => userLogin);
         }

        public void Logout(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var info= handler.ReadJwtToken(token);
            if (info != null)
            {
                var id = info.Claims.SingleOrDefault(p => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid")?.Value;
                var userLogin = _context.userLogins.Where(x => x.Token == token && x.UserId==Convert.ToInt32(id)).FirstOrDefault();
                if (userLogin != null)
                {
                    userLogin.LogoutTime = DateTime.UtcNow;
                    _context.userLogins.Update(userLogin);
                }
            }
        }
    }
}
