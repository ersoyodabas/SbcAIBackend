using Microsoft.AspNetCore.Mvc;
using Sbc.DTO;
using Sbc.SERVICE;

namespace Sbc.API.Controllers
{
    [ApiController]
    [Route("api/userloginattempt")]
    public class UserLoginAttemptController : ControllerBase
    {
        private readonly IUserLoginAttemptService _service;

        public UserLoginAttemptController(IUserLoginAttemptService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllUserLoginAttemptsAsync();
            return result.result ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetUserLoginAttemptByIdAsync(id);
            return result.result ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] UserLoginAttemptDto dto)
        {
            var result = await _service.SaveUserLoginAttemptAsync(dto);
            return result.result ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteUserLoginAttemptAsync(id);
            return result.result ? Ok(result) : NotFound(result);
        }
    }
}
