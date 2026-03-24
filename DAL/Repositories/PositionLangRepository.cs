using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class PositionLangRepository : GenericRepository<position_lang>
    {
        public PositionLangRepository() : base() { }

        public PositionLangRepository(_DbContext context) : base(context) { }
    }
}
