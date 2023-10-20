using HrManagementSystem.Core.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Testcontainers.PostgreSql;

namespace HrManagementSystem.Web.Tests;

public class HrWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _dbContainer = 
        new PostgreSqlBuilder()
            .WithDatabase("hr")
            .WithUsername("hr")
            .WithPassword("password")
            .Build();

    public Task InitializeAsync()
    {
        return _dbContainer.StartAsync();
    }

    public Task DisposeAsync()
    {
        return _dbContainer.DisposeAsync().AsTask();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(config =>
        {
            config.RemoveAll<HrDbContext>();
            config.RemoveAll<DbContextOptions<HrDbContext>>();
            config.AddDbContext<HrDbContext>(dbConfig =>
                dbConfig.UseNpgsql(_dbContainer.GetConnectionString()));
        });
    }
}