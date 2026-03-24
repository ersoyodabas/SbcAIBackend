using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class CardDefaultRepository : GenericRepository<card_default>
    {
        public CardDefaultRepository() : base() { }

        public CardDefaultRepository(_DbContext context) : base(context) { }
    }
}
