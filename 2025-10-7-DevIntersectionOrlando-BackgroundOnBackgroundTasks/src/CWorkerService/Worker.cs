using Shared;

namespace CWorkerService;

public class Worker(ILogger<Worker> logger, ICacheService cacheService) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Job starts
        logger.LogInformation("Starting {jobName}", nameof(Worker));

        // Continue until the app shuts down
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await cacheService.RefreshDashboardCacheAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Job {jobName} threw an exception", nameof(Worker));
            }

            await Task.Delay(5000);
        }
            
        // Job ends
        logger.LogInformation("Stopping {jobName}", nameof(Worker));
        cacheService.RemoveDashboardCache();
    }
}
