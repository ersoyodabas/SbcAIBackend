using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface ISbcCategoryLangService
    {
        Task<ReturnObject> SaveSbcCategoryLangAsync(SbcCategoryLangDto dto);
        Task<ReturnObject> GetAllSbcCategoryLangsAsync();
        Task<ReturnObject> GetSbcCategoryLangByIdAsync(int id);
        Task<ReturnObject> DeleteSbcCategoryLangAsync(int id);
    }
}
