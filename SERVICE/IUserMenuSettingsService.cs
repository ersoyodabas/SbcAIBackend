using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface IUserMenuSettingsService
    {
        Task<ReturnObject> SaveUserMenuSettingsAsync(UserMenuSettingsDto dto);
        Task<ReturnObject> GetAllUserMenuSettingssAsync();
        Task<ReturnObject> GetUserMenuSettingsByIdAsync(int id);
        Task<ReturnObject> DeleteUserMenuSettingsAsync(int id);
    }
}
