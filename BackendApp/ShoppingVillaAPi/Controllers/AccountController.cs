using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingVilla.Business.Account;
using ShoppingVilla.Data.Entities;
using ShoppingVilla.Data.Entities.Interface;

namespace ShoppingVillaAPi.Controllers
{
    [Route("api/Account/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRegisterService _service;

        public AccountController(IUserRegisterService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<int> Register([FromBody] UserRegister user)
        {
            return await _service.RegisterAsync(user);
        }

    }
}
