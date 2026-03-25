using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IFormationService
    {
        Task<ReturnObject> SaveFormationAsync(FormationDto dto);
        Task<ReturnObject> GetAllFormationsAsync();
        Task<ReturnObject> GetFormationByIdAsync(int id);
        Task<ReturnObject> DeleteFormationAsync(int id);
    }
}
