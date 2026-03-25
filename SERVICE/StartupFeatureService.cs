using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class StartupFeatureService : GenericCrudService<startup_feature, StartupFeatureDto>, IStartupFeatureService
    {
        public StartupFeatureService() : this(new StartupFeatureRepository())
        {
        }

        public StartupFeatureService(StartupFeatureRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveStartupFeatureAsync(StartupFeatureDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllStartupFeaturesAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetStartupFeatureByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteStartupFeatureAsync(int id)
            => DeleteAsync(id);
    }
}
