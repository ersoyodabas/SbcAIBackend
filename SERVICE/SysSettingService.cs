using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class SysSettingService : GenericCrudService<sys_setting, SysSettingDto>, ISysSettingService
    {
        public SysSettingService() : this(new SysSettingRepository())
        {
        }

        public SysSettingService(SysSettingRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveSysSettingAsync(SysSettingDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllSysSettingsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetSysSettingByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteSysSettingAsync(int id)
            => DeleteAsync(id);
    }
}
