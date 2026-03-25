using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class StartupFeatureLangService : GenericCrudService<startup_feature_lang, StartupFeatureLangDto>, IStartupFeatureLangService
    {
        public StartupFeatureLangService() : this(new StartupFeatureLangRepository())
        {
        }

        public StartupFeatureLangService(StartupFeatureLangRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveStartupFeatureLangAsync(StartupFeatureLangDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllStartupFeatureLangsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetStartupFeatureLangByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteStartupFeatureLangAsync(int id)
            => DeleteAsync(id);
    }
}
