using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface ISysSettingService
    {
        Task<ReturnObject> SaveSysSettingAsync(SysSettingDto dto);
        Task<ReturnObject> GetAllSysSettingsAsync();
        Task<ReturnObject> GetSysSettingByIdAsync(int id);
        Task<ReturnObject> DeleteSysSettingAsync(int id);
    }
}
