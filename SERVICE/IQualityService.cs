using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IQualityService
    {
        Task<ReturnObject> SaveQualityAsync(QualityDto dto);
        Task<ReturnObject> GetAllQualitysAsync();
        Task<ReturnObject> GetQualityByIdAsync(int id);
        Task<ReturnObject> DeleteQualityAsync(int id);
    }
}
