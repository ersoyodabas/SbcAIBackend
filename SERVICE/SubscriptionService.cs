using Sbc.DAL.Models.Entity;
using Sbc.DAL.Repositories;
using Sbc.DTO;

namespace Sbc.SERVICE
{
    public class SubscriptionService : GenericCrudService<subscription, SubscriptionDto>, ISubscriptionService
    {
        public SubscriptionService() : this(new SubscriptionRepository())
        {
        }

        public SubscriptionService(SubscriptionRepository repository) : base(repository)
        {
        }

        public Task<ReturnObject> SaveSubscriptionAsync(SubscriptionDto dto)
            => SaveAsync(dto);

        public Task<ReturnObject> GetAllSubscriptionsAsync()
            => GetAllAsync();

        public Task<ReturnObject> GetSubscriptionByIdAsync(int id)
            => GetByIdAsync(id);

        public Task<ReturnObject> DeleteSubscriptionAsync(int id)
            => DeleteAsync(id);
    }
}
