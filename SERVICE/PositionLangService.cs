using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class PositionLangService : GenericCrudService<position_lang, PositionLangDto>, IPositionLangService
    {
        public PositionLangService() : this(new PositionLangRepository())
        {
        }

        public PositionLangService(PositionLangRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SavePositionLangAsync(PositionLangDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllPositionLangsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetPositionLangByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeletePositionLangAsync(int id)
            => DeleteAsync(id);
    }
}
