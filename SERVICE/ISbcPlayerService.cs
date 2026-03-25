using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface ISbcPlayerService
    {
        Task<ReturnObject> SaveSbcPlayerAsync(SbcPlayerDto dto);
        Task<ReturnObject> GetAllSbcPlayersAsync();
        Task<ReturnObject> GetSbcPlayerByIdAsync(int id);
        Task<ReturnObject> DeleteSbcPlayerAsync(int id);
    }
}
