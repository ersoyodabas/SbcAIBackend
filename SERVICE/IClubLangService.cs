using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IClubLangService
    {
        Task<ReturnObject> SaveClubLangAsync(ClubLangDto dto);
        Task<ReturnObject> GetAllClubLangsAsync();
        Task<ReturnObject> GetClubLangByIdAsync(int id);
        Task<ReturnObject> DeleteClubLangAsync(int id);
    }
}
