using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class QualityLangService : GenericCrudService<quality_lang, QualityLangDto>, IQualityLangService
    {
        public QualityLangService() : this(new QualityLangRepository())
        {
        }

        public QualityLangService(QualityLangRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveQualityLangAsync(QualityLangDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllQualityLangsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetQualityLangByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteQualityLangAsync(int id)
            => DeleteAsync(id);
    }
}
