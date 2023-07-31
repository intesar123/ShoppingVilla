using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingVilla.Data.Entities;
using ShoppingVilla.Data.Entities.Interface;
using ShoppingVilla.Data.Entities.Models;
using ShoppingVilla.Data.Entities.UnitOfWork;
using System.Formats.Asn1;
using System.Linq;

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
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var users= await _unitOfWork.userRegisterRepository.GetAllAsync();
            return Ok(users);
        }

        [HttpGet(Name = "Get/{Id}")]
        public async Task<UserRegister> Get(int Id)
        {
            return await _unitOfWork.userRegisterRepository.GetByIdAsync(Id);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserRegister user)
        {
            if (user.Id==0)
            {
                _unitOfWork.userRegisterRepository.CreateAsync(user);
            }
            else
            {
                _unitOfWork.userRegisterRepository.UpdateAsync(user);
            }
            var result=  await _unitOfWork.SaveChangesAsync();
            return Ok(result);
        }                               

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserRegister user)
        {
             _unitOfWork.userRegisterRepository.UpdateAsync(user);
            var result= await _unitOfWork.SaveChangesAsync();
            return Ok(result);
        }
        [HttpDelete(Name = "Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var user = await _unitOfWork.userRegisterRepository.GetByIdAsync(Id);
            _unitOfWork.userRegisterRepository.DeleteAsync(user);
            var result =await _unitOfWork.SaveChangesAsync();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLogin user)
        {
            var userLogin =_unitOfWork.userLoginRepository.Login(user);
            var result = await _unitOfWork.SaveChangesAsync();
            if (result != 1)
            {
                return BadRequest();
            }
            return Ok( new { Token = userLogin.Result.Token, UserId=userLogin.Result.UserId });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout(string Token)
        {
            _unitOfWork.userLoginRepository.Logout(Token);
            var result = await _unitOfWork.SaveChangesAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] Role role)
        {
            _unitOfWork.roleRepository.CreateAsync(role);
            var result= await _unitOfWork.SaveChangesAsync();
            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        public  async Task<IActionResult> Roles()
        {
            var roles= await _unitOfWork.roleRepository.GetAllAsync();
            return Ok(roles);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRole([FromBody] Role role)
        {
            _unitOfWork.roleRepository.UpdateAsync(role);
            var result= await _unitOfWork.SaveChangesAsync();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetRole(int Id)
        {
            var role=await _unitOfWork.roleRepository.GetByIdAsync(Id);
            return Ok(role);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteRole(int Id)
        {
            _unitOfWork.roleRepository.DeleteAsync(Id);
            var result= await _unitOfWork.SaveChangesAsync();
            return Ok(result);

        }
    }
}
