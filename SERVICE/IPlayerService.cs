using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IPlayerService
    {
        Task<ReturnObject> SavePlayerAsync(PlayerDto dto);
        Task<ReturnObject> GetAllPlayersAsync();
        Task<ReturnObject> GetPlayerByIdAsync(int id);
        Task<ReturnObject> DeletePlayerAsync(int id);
    }
}
