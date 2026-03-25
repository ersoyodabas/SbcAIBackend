using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class SbcCategoryLangService : GenericCrudService<sbc_category_lang, SbcCategoryLangDto>, ISbcCategoryLangService
    {
        public SbcCategoryLangService() : this(new SbcCategoryLangRepository())
        {
        }

        public SbcCategoryLangService(SbcCategoryLangRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveSbcCategoryLangAsync(SbcCategoryLangDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllSbcCategoryLangsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetSbcCategoryLangByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteSbcCategoryLangAsync(int id)
            => DeleteAsync(id);
    }
}
