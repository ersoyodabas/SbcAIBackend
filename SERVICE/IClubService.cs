using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IClubService
    {
        Task<ReturnObject> SaveClubAsync(ClubDto dto);
        Task<ReturnObject> GetAllClubsAsync();
        Task<ReturnObject> GetClubByIdAsync(int id);
        Task<ReturnObject> DeleteClubAsync(int id);
    }
}
