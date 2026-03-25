using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IFormationPositionService
    {
        Task<ReturnObject> SaveFormationPositionAsync(FormationPositionDto dto);
        Task<ReturnObject> GetAllFormationPositionsAsync();
        Task<ReturnObject> GetFormationPositionByIdAsync(int id);
        Task<ReturnObject> DeleteFormationPositionAsync(int id);
    }
}
