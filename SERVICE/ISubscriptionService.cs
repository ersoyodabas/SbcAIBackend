using Sbc.DTO;

namespace Sbc.SERVICE
{
    public interface ISubscriptionService
    {
        Task<ReturnObject> SaveSubscriptionAsync(SubscriptionDto dto);
        Task<ReturnObject> GetAllSubscriptionsAsync();
        Task<ReturnObject> GetSubscriptionByIdAsync(int id);
        Task<ReturnObject> DeleteSubscriptionAsync(int id);
    }
}
