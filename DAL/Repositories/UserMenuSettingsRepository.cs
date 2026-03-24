using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class UserMenuSettingsRepository : GenericRepository<user_menu_settings>
    {
        public UserMenuSettingsRepository() : base() { }

        public UserMenuSettingsRepository(_DbContext context) : base(context) { }
    }
}
