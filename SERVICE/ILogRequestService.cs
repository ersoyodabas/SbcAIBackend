using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface ILogRequestService
    {
        Task<ReturnObject> SaveLogRequestAsync(LogRequestDto dto);
        Task<ReturnObject> GetAllLogRequestsAsync();
        Task<ReturnObject> GetLogRequestByIdAsync(int id);
        Task<ReturnObject> DeleteLogRequestAsync(int id);
    }
}
