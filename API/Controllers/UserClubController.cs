using Microsoft.AspNetCore.Mvc;
using Sbc.DTO;
using Sbc.SERVICE;

namespace Sbc.API.Controllers
{
    [ApiController]
    [Route("api/userclub")]
    public class UserClubController : ControllerBase
    {
        private readonly IUserClubService _service;

        public UserClubController(IUserClubService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllUserClubsAsync();
            return result.result ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetUserClubByIdAsync(id);
            return result.result ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] UserClubDto dto)
        {
            var result = await _service.SaveUserClubAsync(dto);
            return result.result ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteUserClubAsync(id);
            return result.result ? Ok(result) : NotFound(result);
        }
    }
}
