using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class NationLangService : GenericCrudService<nation_lang, NationLangDto>, INationLangService
    {
        public NationLangService() : this(new NationLangRepository())
        {
        }

        public NationLangService(NationLangRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveNationLangAsync(NationLangDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllNationLangsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetNationLangByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteNationLangAsync(int id)
            => DeleteAsync(id);
    }
}
