using Shared;

#pragma warning disable 4014

namespace AIHostedService.Dashboard;

public class DashboardCacheRefresherHostedService(ILogger<DashboardCacheRefresherHostedService> logger, ICacheService cacheService) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Starting {jobName}", nameof(DashboardCacheRefresherHostedService));
        
        await RefreshCacheAsync(cancellationToken);
    }
        
    private async Task RefreshCacheAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await cacheService.RefreshDashboardCacheAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Job {jobName} threw an exception", nameof(DashboardCacheRefresherHostedService));
            }

            await Task.Delay(5000, stoppingToken);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Stopping {jobName}", nameof(DashboardCacheRefresherHostedService));

        // Perform any cleanup here
        cacheService.RemoveDashboardCache();

        return Task.CompletedTask;
    }
}
