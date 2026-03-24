using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class RarityRepository : GenericRepository<rarity>
    {
        public RarityRepository() : base() { }

        public RarityRepository(_DbContext context) : base(context) { }
    }
}
