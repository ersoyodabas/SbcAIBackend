using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IPositionLangService
    {
        Task<ReturnObject> SavePositionLangAsync(PositionLangDto dto);
        Task<ReturnObject> GetAllPositionLangsAsync();
        Task<ReturnObject> GetPositionLangByIdAsync(int id);
        Task<ReturnObject> DeletePositionLangAsync(int id);
    }
}
