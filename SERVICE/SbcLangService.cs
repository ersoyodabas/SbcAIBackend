using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class SbcLangService : GenericCrudService<sbc_lang, SbcLangDto>, ISbcLangService
    {
        public SbcLangService() : this(new SbcLangRepository())
        {
        }

        public SbcLangService(SbcLangRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveSbcLangAsync(SbcLangDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllSbcLangsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetSbcLangByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteSbcLangAsync(int id)
            => DeleteAsync(id);
    }
}
