using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface ILeagueService
    {
        Task<ReturnObject> SaveLeagueAsync(LeagueDto dto);
        Task<ReturnObject> GetAllLeaguesAsync();
        Task<ReturnObject> GetLeagueByIdAsync(int id);
        Task<ReturnObject> DeleteLeagueAsync(int id);
    }
}
