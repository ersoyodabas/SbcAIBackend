using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IPackCategoryService
    {
        Task<ReturnObject> SavePackCategoryAsync(PackCategoryDto dto);
        Task<ReturnObject> GetAllPackCategorysAsync();
        Task<ReturnObject> GetPackCategoryByIdAsync(int id);
        Task<ReturnObject> DeletePackCategoryAsync(int id);
    }
}
