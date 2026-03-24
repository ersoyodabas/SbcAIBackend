using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class RarityLangRepository : GenericRepository<rarity_lang>
    {
        public RarityLangRepository() : base() { }

        public RarityLangRepository(_DbContext context) : base(context) { }
    }
}
