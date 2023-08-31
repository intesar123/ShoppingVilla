using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingVilla.Common
{
    public static class Helpers
    {
        public static string BetweenStr(string STR, string FirstString, string LastString)
        {
            string FinalString;
            int Pos1 = STR.IndexOf(FirstString) + FirstString.Length;
            int Pos2 = STR.IndexOf(LastString);
            FinalString = STR.Substring(Pos1, Pos2 - Pos1);
            return FinalString;
        }

        public static int getUserIdFromToken(string Token)
        {
            int userId = 0;
            var handler = new JwtSecurityTokenHandler();
            var info = handler.ReadJwtToken(Token);
            if (info != null)
            {
                 userId = Convert.ToInt32(info.Claims.SingleOrDefault(p => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid")?.Value);
            }
            return userId;
        }
    }
}
