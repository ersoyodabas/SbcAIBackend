using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class PositionRepository : GenericRepository<position>
    {
        public PositionRepository() : base() { }

        public PositionRepository(_DbContext context) : base(context) { }
    }
}
