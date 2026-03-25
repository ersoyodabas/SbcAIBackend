using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface ISbcService
    {
        Task<ReturnObject> SaveSbcAsync(SbcDto dto);
        Task<ReturnObject> GetAllSbcsAsync();
        Task<ReturnObject> GetSbcByIdAsync(int id);
        Task<ReturnObject> DeleteSbcAsync(int id);
    }
}
