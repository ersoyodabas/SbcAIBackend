using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class LeagueLangService : GenericCrudService<league_lang, LeagueLangDto>, ILeagueLangService
    {
        public LeagueLangService() : this(new LeagueLangRepository())
        {
        }

        public LeagueLangService(LeagueLangRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveLeagueLangAsync(LeagueLangDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllLeagueLangsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetLeagueLangByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteLeagueLangAsync(int id)
            => DeleteAsync(id);
    }
}
