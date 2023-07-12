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

        [HttpGet]
        public async Task<IEnumerable<UserRegister>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet( Name ="Get/{Id}")]
        public async Task<UserRegister> Get(int Id)
        {
            return await _service.GetByIdAsync(Id);
        }

        [HttpPost]
        public async Task<int> Register([FromBody] UserRegister user)
        {
            return await _service.RegisterAsync(user);
        }

        [HttpPut]
        public async Task<int> Update([FromBody] UserRegister user)
        {
            return await _service.UpdateAsync(user);
        }
        [HttpDelete(Name ="Delete/{Id}")]
        public async Task<int> Delete(int Id)
        {
            return await _service.DeleteAsync(Id);
        }
    }
}
