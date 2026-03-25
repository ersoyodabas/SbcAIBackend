using Microsoft.AspNetCore.Mvc;
using Sbc.DTO;
using Sbc.SERVICE;

namespace Sbc.API.Controllers
{
    [ApiController]
    [Route("api/coincard")]
    public class CoinCardController : ControllerBase
    {
        private readonly ICoinCardService _service;

        public CoinCardController(ICoinCardService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllCoinCardsAsync();
            return result.result ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetCoinCardByIdAsync(id);
            return result.result ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] CoinCardDto dto)
        {
            var result = await _service.SaveCoinCardAsync(dto);
            return result.result ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteCoinCardAsync(id);
            return result.result ? Ok(result) : NotFound(result);
        }

        [HttpDelete("deleteLowedRatioCards")]
        public async Task<IActionResult> DeleteLowedRatioCards()
        {
            var result = await _service.DeleteLowedRatioCardsAsync();
            return result.result ? Ok(result) : BadRequest(result);
        }
    }
}
