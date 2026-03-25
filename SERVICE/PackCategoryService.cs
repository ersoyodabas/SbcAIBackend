using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class PackCategoryService : GenericCrudService<pack_category, PackCategoryDto>, IPackCategoryService
    {
        public PackCategoryService() : this(new PackCategoryRepository())
        {
        }

        public PackCategoryService(PackCategoryRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SavePackCategoryAsync(PackCategoryDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllPackCategorysAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetPackCategoryByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeletePackCategoryAsync(int id)
            => DeleteAsync(id);
    }
}
