using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class PlayerRepository : GenericRepository<player>
    {
        public PlayerRepository() : base() { }

        public PlayerRepository(_DbContext context) : base(context) { }
    }
}
