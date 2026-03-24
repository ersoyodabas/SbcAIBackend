using Sbc.DAL.Models.Entity;

namespace Sbc.DAL.Repositories
{
    public class SubscriptionRepository : GenericRepository<subscription>
    {
        public SubscriptionRepository() : base() { }

        public SubscriptionRepository(_DbContext context) : base(context) { }
    }
}
