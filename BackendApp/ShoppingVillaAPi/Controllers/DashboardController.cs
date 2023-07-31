using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShoppingVilla.Data.Entities.Models.Dashboard;
using ShoppingVilla.Data.Entities.UnitOfWork;

namespace ShoppingVillaAPi.Controllers
{
    
    [Route("api/Dashboard/[action]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        #region Modules
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetModules()
        {
            var modules = await _unitOfWork.moduleRepository.GetAllAsync();
            return Ok(modules);
        }
        [HttpPost]
        public async Task<IActionResult> CreateModule([FromBody] Module module)
        {
            _unitOfWork.moduleRepository.CreateAsync(module);
            var result = await _unitOfWork.SaveChangesAsync();
            return Ok(result);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateModule([FromBody] Module module)
        {
            _unitOfWork.moduleRepository.UpdateAsync(module);
            var result = await _unitOfWork.SaveChangesAsync();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetModule(int Id)
        {
            var module = await _unitOfWork.moduleRepository.GetByIdAsync(Id);
            return Ok(module);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteModule(int Id)
        {
            _unitOfWork.moduleRepository.DeleteAsync(Id);
            var result = await _unitOfWork.SaveChangesAsync();
            return Ok(result);
        }
        #endregion

        #region Menu
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetMenus()
        {
            var menus= await _unitOfWork.menuRepository.GetAllAsync();
            return Ok(menus);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetMenusByModule(int ModuleId)
        {
            var menus = await _unitOfWork.menuRepository.GetByModuleAsync(ModuleId);
            return Ok(menus);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMenu([FromBody] Menu menu)
        {
            _unitOfWork.menuRepository.CreateAsync(menu);
            var result =await _unitOfWork.SaveChangesAsync();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMenu([FromBody] Menu menu)
        {
            _unitOfWork.menuRepository.UpdateAsync(menu);
            var result= await _unitOfWork.SaveChangesAsync();
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMenu(int Id)
        {
            _unitOfWork.menuRepository.DeleteAsync(Id);
            var result = await _unitOfWork.SaveChangesAsync();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetMenu(int Id)
        {
            var menu= await _unitOfWork.menuRepository.GetByIdAsync(Id);
            return Ok(menu);
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(int Id)
        {
            var user = await _unitOfWork.userRegisterRepository.GetByIdAsync(Id);
            return Ok(user);
        }

        #endregion

    }
}
