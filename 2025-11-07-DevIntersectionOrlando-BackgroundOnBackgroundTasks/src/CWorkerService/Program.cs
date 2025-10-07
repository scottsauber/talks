using CWorkerService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddDemoServices();

var host = builder.Build();

await host.RunAsync();
