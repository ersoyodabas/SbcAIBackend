using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class VersionService : GenericCrudService<version, VersionDto>, IVersionService
    {
        public VersionService() : this(new VersionRepository())
        {
        }

        public VersionService(VersionRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveVersionAsync(VersionDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllVersionsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetVersionByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteVersionAsync(int id)
            => DeleteAsync(id);
    }
}
