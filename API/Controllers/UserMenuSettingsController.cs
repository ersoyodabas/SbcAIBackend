using Microsoft.AspNetCore.Mvc;
using Sbc.DTO;
using Sbc.SERVICE;

namespace Sbc.API.Controllers
{
    [ApiController]
    [Route("api/usermenusettings")]
    public class UserMenuSettingsController : ControllerBase
    {
        private readonly IUserMenuSettingsService _service;

        public UserMenuSettingsController(IUserMenuSettingsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllUserMenuSettingssAsync();
            return result.result ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetUserMenuSettingsByIdAsync(id);
            return result.result ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] UserMenuSettingsDto dto)
        {
            var result = await _service.SaveUserMenuSettingsAsync(dto);
            return result.result ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteUserMenuSettingsAsync(id);
            return result.result ? Ok(result) : NotFound(result);
        }
    }
}
