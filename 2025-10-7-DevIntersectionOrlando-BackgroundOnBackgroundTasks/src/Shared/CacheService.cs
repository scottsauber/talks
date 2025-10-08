using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

namespace Shared;

public interface ICacheService
{
    Task RefreshDashboardCacheAsync();
    void RemoveDashboardCache();
}

public class CacheService(IDistributedCache cache, ILogger<CacheService> logger) : ICacheService
{
    public async Task RefreshDashboardCacheAsync()
    {
        var rng = Random.Shared;
        var dashboardResult = new DashboardResult
        {
            AverageSale = rng.Next(1, 2_000),
            LastUpdated = DateTime.UtcNow,
            NumberOfSales = rng.Next(1, 10_000)
        };
        var encodedDashboard = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(dashboardResult));

        await cache.SetAsync(CacheKeys.Dashboard, encodedDashboard, new DistributedCacheEntryOptions());

        logger.LogInformation("{cacheKey} cache refreshed", CacheKeys.Dashboard);
    }

    public void RemoveDashboardCache()
    {
        cache.Remove(CacheKeys.Dashboard);
    }
}
