using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class SbcCategoryService : GenericCrudService<sbc_category, SbcCategoryDto>, ISbcCategoryService
    {
        public SbcCategoryService() : this(new SbcCategoryRepository())
        {
        }

        public SbcCategoryService(SbcCategoryRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveSbcCategoryAsync(SbcCategoryDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllSbcCategorysAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetSbcCategoryByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteSbcCategoryAsync(int id)
            => DeleteAsync(id);
    }
}
