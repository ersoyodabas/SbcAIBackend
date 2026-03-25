using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IPositionService
    {
        Task<ReturnObject> SavePositionAsync(PositionDto dto);
        Task<ReturnObject> GetAllPositionsAsync();
        Task<ReturnObject> GetPositionByIdAsync(int id);
        Task<ReturnObject> DeletePositionAsync(int id);
    }
}
