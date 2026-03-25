using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IStartupFeatureLangService
    {
        Task<ReturnObject> SaveStartupFeatureLangAsync(StartupFeatureLangDto dto);
        Task<ReturnObject> GetAllStartupFeatureLangsAsync();
        Task<ReturnObject> GetStartupFeatureLangByIdAsync(int id);
        Task<ReturnObject> DeleteStartupFeatureLangAsync(int id);
    }
}
