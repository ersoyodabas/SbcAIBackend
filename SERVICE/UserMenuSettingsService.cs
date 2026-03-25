using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class UserMenuSettingsService : GenericCrudService<user_menu_settings, UserMenuSettingsDto>, IUserMenuSettingsService
    {
        public UserMenuSettingsService() : this(new UserMenuSettingsRepository())
        {
        }

        public UserMenuSettingsService(UserMenuSettingsRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveUserMenuSettingsAsync(UserMenuSettingsDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllUserMenuSettingssAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetUserMenuSettingsByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteUserMenuSettingsAsync(int id)
            => DeleteAsync(id);
    }
}
