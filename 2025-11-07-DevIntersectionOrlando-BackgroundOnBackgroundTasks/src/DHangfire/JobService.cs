using Hangfire;

namespace DHangfire;

public interface IJobService
{
    Task ExternalJob();
}

public class JobService : IJobService
{
    public async Task ExternalJob()
    {
        await Task.Delay(5000);
        Console.WriteLine("Named method recurring every minute!");
    }

}
