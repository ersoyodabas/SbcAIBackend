using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IRarityService
    {
        Task<ReturnObject> SaveRarityAsync(RarityDto dto);
        Task<ReturnObject> GetAllRaritysAsync();
        Task<ReturnObject> GetRarityByIdAsync(int id);
        Task<ReturnObject> DeleteRarityAsync(int id);
    }
}
