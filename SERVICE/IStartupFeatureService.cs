using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IStartupFeatureService
    {
        Task<ReturnObject> SaveStartupFeatureAsync(StartupFeatureDto dto);
        Task<ReturnObject> GetAllStartupFeaturesAsync();
        Task<ReturnObject> GetStartupFeatureByIdAsync(int id);
        Task<ReturnObject> DeleteStartupFeatureAsync(int id);
    }
}
