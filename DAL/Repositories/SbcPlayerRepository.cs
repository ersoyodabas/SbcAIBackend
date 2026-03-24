using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class SbcPlayerRepository : GenericRepository<sbc_player>
    {
        public SbcPlayerRepository() : base() { }

        public SbcPlayerRepository(_DbContext context) : base(context) { }
    }
}
