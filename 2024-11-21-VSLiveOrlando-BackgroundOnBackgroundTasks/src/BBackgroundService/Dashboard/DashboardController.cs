using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Shared;

namespace BBackgroundService.Dashboard;

[ApiController]
[Route("[controller]")]
public class DashboardController(IDistributedCache cache) : Controller
{
    [HttpGet]
    public async Task<DashboardResult?> Get()
    {
        var encodedDashboard = await cache.GetAsync(CacheKeys.Dashboard);
        var dashboard = JsonSerializer.Deserialize<DashboardResult>(Encoding.UTF8.GetString(encodedDashboard));
        return dashboard;
    }
}
