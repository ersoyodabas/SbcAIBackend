using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class QualityService : GenericCrudService<quality, QualityDto>, IQualityService
    {
        public QualityService() : this(new QualityRepository())
        {
        }

        public QualityService(QualityRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveQualityAsync(QualityDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllQualitysAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetQualityByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteQualityAsync(int id)
            => DeleteAsync(id);
    }
}
