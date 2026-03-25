using Microsoft.AspNetCore.Mvc;
using Sbc.DTO;
using Sbc.SERVICE;

namespace Sbc.API.Controllers
{
    [ApiController]
    [Route("api/vwrequestlog")]
    public class VwRequestLogController : ControllerBase
    {
        private readonly IVwRequestLogService _service;

        public VwRequestLogController(IVwRequestLogService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllVwRequestLogsAsync();
            return result.result ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetVwRequestLogByIdAsync(id);
            return result.result ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] VwRequestLogDto dto)
        {
            var result = await _service.SaveVwRequestLogAsync(dto);
            return result.result ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteVwRequestLogAsync(id);
            return result.result ? Ok(result) : NotFound(result);
        }
    }
}
