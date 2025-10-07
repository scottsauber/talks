// ReSharper disable All
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace DHangfire.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HangfireController(IBackgroundJobClient backgroundJobClient)
{
    [HttpGet]
    public void Trigger()
    {
        backgroundJobClient.Enqueue(
            () => TriggeredFromControllerAsync("Hello from the Controller!"));
    }

    [JobDisplayName("Triggered from Controller with - {0}")]
    public static async Task TriggeredFromControllerAsync(string value)
    {
        await Task.Delay(5000);
        Console.WriteLine(value);
    }
}
