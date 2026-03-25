using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class LogRequestService : GenericCrudService<log_request, LogRequestDto>, ILogRequestService
    {
        public LogRequestService() : this(new LogRequestRepository())
        {
        }

        public LogRequestService(LogRequestRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveLogRequestAsync(LogRequestDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllLogRequestsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetLogRequestByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteLogRequestAsync(int id)
            => DeleteAsync(id);
    }
}
