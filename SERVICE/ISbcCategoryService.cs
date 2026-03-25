using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface ISbcCategoryService
    {
        Task<ReturnObject> SaveSbcCategoryAsync(SbcCategoryDto dto);
        Task<ReturnObject> GetAllSbcCategorysAsync();
        Task<ReturnObject> GetSbcCategoryByIdAsync(int id);
        Task<ReturnObject> DeleteSbcCategoryAsync(int id);
    }
}
