using Microsoft.AspNetCore.Mvc;
using Sbc.DTO;
using Sbc.SERVICE;

namespace Sbc.API.Controllers
{
    [ApiController]
    [Route("api/sbccategorylang")]
    public class SbcCategoryLangController : ControllerBase
    {
        private readonly ISbcCategoryLangService _service;

        public SbcCategoryLangController(ISbcCategoryLangService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllSbcCategoryLangsAsync();
            return result.result ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetSbcCategoryLangByIdAsync(id);
            return result.result ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] SbcCategoryLangDto dto)
        {
            var result = await _service.SaveSbcCategoryLangAsync(dto);
            return result.result ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteSbcCategoryLangAsync(id);
            return result.result ? Ok(result) : NotFound(result);
        }
    }
}
