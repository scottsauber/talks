var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.DotNetAspireDemo_ApiService>("apiservice");

builder.AddProject<Projects.DotNetAspireDemo_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
