using Microsoft.AspNetCore.Mvc;
using Sbc.DTO;
using Sbc.SERVICE;

namespace Sbc.API.Controllers
{
    [ApiController]
    [Route("api/usercoinsupplier")]
    public class UserCoinSupplierController : ControllerBase
    {
        private readonly IUserCoinSupplierService _service;

        public UserCoinSupplierController(IUserCoinSupplierService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllUserCoinSuppliersAsync();
            return result.result ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetUserCoinSupplierByIdAsync(id);
            return result.result ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] UserCoinSupplierDto dto)
        {
            var result = await _service.SaveUserCoinSupplierAsync(dto);
            return result.result ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteUserCoinSupplierAsync(id);
            return result.result ? Ok(result) : NotFound(result);
        }
    }
}
