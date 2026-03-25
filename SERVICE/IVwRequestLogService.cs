using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IVwRequestLogService
    {
        Task<ReturnObject> SaveVwRequestLogAsync(VwRequestLogDto dto);
        Task<ReturnObject> GetAllVwRequestLogsAsync();
        Task<ReturnObject> GetVwRequestLogByIdAsync(int id);
        Task<ReturnObject> DeleteVwRequestLogAsync(int id);
    }
}
