using Microsoft.AspNetCore.Mvc;
using Sbc.DTO;
using Sbc.SERVICE;

namespace Sbc.API.Controllers
{
    [ApiController]
    [Route("api/usersbcsubmit")]
    public class UserSbcSubmitController : ControllerBase
    {
        private readonly IUserSbcSubmitService _service;

        public UserSbcSubmitController(IUserSbcSubmitService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllUserSbcSubmitsAsync();
            return result.result ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetUserSbcSubmitByIdAsync(id);
            return result.result ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] UserSbcSubmitDto dto)
        {
            var result = await _service.SaveUserSbcSubmitAsync(dto);
            return result.result ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteUserSbcSubmitAsync(id);
            return result.result ? Ok(result) : NotFound(result);
        }
    }
}
