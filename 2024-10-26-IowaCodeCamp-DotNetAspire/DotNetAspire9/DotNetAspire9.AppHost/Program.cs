var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.DotNetAspire9_ApiService>("apiservice");

builder.AddProject<Projects.DotNetAspire9_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
