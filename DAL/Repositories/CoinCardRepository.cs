using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class CoinCardRepository : GenericRepository<coin_card>
    {
        public CoinCardRepository() : base() { }

        public CoinCardRepository(_DbContext context) : base(context) { }
    }
}
