using Microsoft.AspNetCore.Mvc;
using Sbc.DTO;
using Sbc.SERVICE;

namespace Sbc.API.Controllers
{
    [ApiController]
    [Route("api/userstartup")]
    public class UserStartupController : ControllerBase
    {
        private readonly IUserStartupService _service;

        public UserStartupController(IUserStartupService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllUserStartupsAsync();
            return result.result ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetUserStartupByIdAsync(id);
            return result.result ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] UserStartupDto dto)
        {
            var result = await _service.SaveUserStartupAsync(dto);
            return result.result ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteUserStartupAsync(id);
            return result.result ? Ok(result) : NotFound(result);
        }
    }
}
