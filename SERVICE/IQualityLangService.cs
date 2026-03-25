using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IQualityLangService
    {
        Task<ReturnObject> SaveQualityLangAsync(QualityLangDto dto);
        Task<ReturnObject> GetAllQualityLangsAsync();
        Task<ReturnObject> GetQualityLangByIdAsync(int id);
        Task<ReturnObject> DeleteQualityLangAsync(int id);
    }
}
