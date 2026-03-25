using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class VwRequestLogService : GenericCrudService<vw_request_log, VwRequestLogDto>, IVwRequestLogService
    {
        public VwRequestLogService() : this(new VwRequestLogRepository())
        {
        }

        public VwRequestLogService(VwRequestLogRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveVwRequestLogAsync(VwRequestLogDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllVwRequestLogsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetVwRequestLogByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteVwRequestLogAsync(int id)
            => DeleteAsync(id);
    }
}
