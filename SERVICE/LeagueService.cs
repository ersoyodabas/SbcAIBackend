using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class LeagueService : GenericCrudService<league, LeagueDto>, ILeagueService
    {
        public LeagueService() : this(new LeagueRepository())
        {
        }

        public LeagueService(LeagueRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveLeagueAsync(LeagueDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllLeaguesAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetLeagueByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteLeagueAsync(int id)
            => DeleteAsync(id);
    }
}
