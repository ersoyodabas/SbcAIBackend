using Microsoft.AspNetCore.Mvc;
using Sbc.DTO;
using Sbc.SERVICE;

namespace Sbc.API.Controllers
{
    [ApiController]
    [Route("api/announcement")]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementService _service;

        public AnnouncementController(IAnnouncementService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAnnouncementsAsync();
            return result.result ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetAnnouncementByIdAsync(id);
            return result.result ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] AnnouncementDto dto)
        {
            var result = await _service.SaveAnnouncementAsync(dto);
            return result.result ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAnnouncementAsync(id);
            return result.result ? Ok(result) : NotFound(result);
        }
    }
}
