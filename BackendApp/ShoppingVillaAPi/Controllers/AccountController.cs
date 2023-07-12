using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingVilla.Business.Account;
using ShoppingVilla.Data.Entities;
using ShoppingVilla.Data.Entities.Interface;
using ShoppingVilla.Data.Entities.UnitOfWork;

namespace ShoppingVillaAPi.Controllers
{
    [Route("api/Account/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users= await _unitOfWork.userRegisterRepository.GetAllAsync();
            return Ok(users);
        }
         
        //[HttpGet( Name ="Get/{Id}")]
        //public async Task<UserRegister> Get(int Id)
        //{
        //    return await _service.GetByIdAsync(Id);
        //}

        //[HttpPost]
        //public async Task<int> Register([FromBody] UserRegister user)
        //{
        //    return await _service.RegisterAsync(user);
        //}

        //[HttpPut]
        //public async Task<int> Update([FromBody] UserRegister user)
        //{
        //    return await _service.UpdateAsync(user);
        //}
        //[HttpDelete(Name ="Delete/{Id}")]
        //public async Task<int> Delete(int Id)
        //{
        //    return await _service.DeleteAsync(Id);
        //}
    }
}
