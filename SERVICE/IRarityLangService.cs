using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IRarityLangService
    {
        Task<ReturnObject> SaveRarityLangAsync(RarityLangDto dto);
        Task<ReturnObject> GetAllRarityLangsAsync();
        Task<ReturnObject> GetRarityLangByIdAsync(int id);
        Task<ReturnObject> DeleteRarityLangAsync(int id);
    }
}
