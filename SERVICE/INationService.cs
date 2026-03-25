using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface INationService
    {
        Task<ReturnObject> SaveNationAsync(NationDto dto);
        Task<ReturnObject> GetAllNationsAsync();
        Task<ReturnObject> GetNationByIdAsync(int id);
        Task<ReturnObject> DeleteNationAsync(int id);
    }
}
