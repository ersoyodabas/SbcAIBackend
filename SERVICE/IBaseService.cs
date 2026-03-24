namespace Sbc.SERVICE
{
    /// <summary>
    /// Base service interface for business logic
    /// </summary>
    public interface IBaseService
    {
        Task<bool> HealthCheckAsync();
    }
}
