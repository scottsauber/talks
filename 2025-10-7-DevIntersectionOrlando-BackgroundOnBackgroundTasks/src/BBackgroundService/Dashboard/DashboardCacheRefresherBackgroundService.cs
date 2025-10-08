using Shared;

namespace BBackgroundService.Dashboard;

public class DashboardCacheRefresherBackgroundService(ILogger<DashboardCacheRefresherBackgroundService> logger, ICacheService cacheService) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Job starts
        logger.LogInformation("Starting {jobName}", nameof(DashboardCacheRefresherBackgroundService));

        // Continue until the app shuts down
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await cacheService.RefreshDashboardCacheAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Job {jobName} threw an exception", nameof(DashboardCacheRefresherBackgroundService));
            }

            await Task.Delay(5000);
        }
            
        // Job ends
        logger.LogInformation("Stopping {jobName}", nameof(DashboardCacheRefresherBackgroundService));
        cacheService.RemoveDashboardCache();
    }
}
