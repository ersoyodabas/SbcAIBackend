using Microsoft.AspNetCore.Mvc;
using Sbc.DTO;
using Sbc.SERVICE;

namespace Sbc.API.Controllers
{
    [ApiController]
    [Route("api/startupfeaturelang")]
    public class StartupFeatureLangController : ControllerBase
    {
        private readonly IStartupFeatureLangService _service;

        public StartupFeatureLangController(IStartupFeatureLangService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllStartupFeatureLangsAsync();
            return result.result ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetStartupFeatureLangByIdAsync(id);
            return result.result ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] StartupFeatureLangDto dto)
        {
            var result = await _service.SaveStartupFeatureLangAsync(dto);
            return result.result ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteStartupFeatureLangAsync(id);
            return result.result ? Ok(result) : NotFound(result);
        }
    }
}
