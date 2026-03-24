namespace Sbc.SERVICE
{
    /// <summary>
    /// Base service implementation for business logic
    /// </summary>
    public class BaseService : IBaseService
    {
        public Task<bool> HealthCheckAsync()
        {
            return Task.FromResult(true);
        }
    }
}
