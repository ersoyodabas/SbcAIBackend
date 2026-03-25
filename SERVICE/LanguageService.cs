using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class LanguageService : GenericCrudService<language, LanguageDto>, ILanguageService
    {
        public LanguageService() : this(new LanguageRepository())
        {
        }

        public LanguageService(LanguageRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveLanguageAsync(LanguageDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllLanguagesAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetLanguageByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteLanguageAsync(int id)
            => DeleteAsync(id);
    }
}
