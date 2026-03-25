using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IFeatureService
    {
        Task<ReturnObject> SaveFeatureAsync(FeatureDto dto);
        Task<ReturnObject> GetAllFeaturesAsync();
        Task<ReturnObject> GetFeatureByIdAsync(int id);
        Task<ReturnObject> DeleteFeatureAsync(int id);
    }
}
