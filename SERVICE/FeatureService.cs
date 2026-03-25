using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class FeatureService : GenericCrudService<feature, FeatureDto>, IFeatureService
    {
        public FeatureService() : this(new FeatureRepository())
        {
        }

        public FeatureService(FeatureRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveFeatureAsync(FeatureDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllFeaturesAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetFeatureByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteFeatureAsync(int id)
            => DeleteAsync(id);
    }
}
