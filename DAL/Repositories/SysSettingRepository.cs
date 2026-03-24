using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class SysSettingRepository : GenericRepository<sys_setting>
    {
        public SysSettingRepository() : base() { }

        public SysSettingRepository(_DbContext context) : base(context) { }
    }
}
