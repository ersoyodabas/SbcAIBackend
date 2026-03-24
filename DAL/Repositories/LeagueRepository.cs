using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class LeagueRepository : GenericRepository<league>
    {
        public LeagueRepository() : base() { }

        public LeagueRepository(_DbContext context) : base(context) { }
    }
}
