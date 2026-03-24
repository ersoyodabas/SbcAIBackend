namespace Sbc.WORKER
{
    /// <summary>
    /// Base worker service for background tasks
    /// </summary>
    public interface IWorkerService
    {
        Task StartAsync(CancellationToken cancellationToken);
        Task StopAsync(CancellationToken cancellationToken);
    }
}
