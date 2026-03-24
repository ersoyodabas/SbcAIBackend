using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class LeagueLangRepository : GenericRepository<league_lang>
    {
        public LeagueLangRepository() : base() { }

        public LeagueLangRepository(_DbContext context) : base(context) { }
    }
}
