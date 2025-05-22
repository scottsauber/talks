var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.StarterAppAspire_ApiService>("apiservice");

builder.AddProject<Projects.StarterAppAspire_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
