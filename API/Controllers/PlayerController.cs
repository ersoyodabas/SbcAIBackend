using Microsoft.AspNetCore.Mvc;
using Sbc.DTO;
using Sbc.SERVICE;

namespace Sbc.API.Controllers
{
    [ApiController]
    [Route("api/player")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _service;

        public PlayerController(IPlayerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllPlayersAsync();
            return result.result ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetPlayerByIdAsync(id);
            return result.result ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] PlayerDto dto)
        {
            var result = await _service.SavePlayerAsync(dto);
            return result.result ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeletePlayerAsync(id);
            return result.result ? Ok(result) : NotFound(result);
        }
    }
}
