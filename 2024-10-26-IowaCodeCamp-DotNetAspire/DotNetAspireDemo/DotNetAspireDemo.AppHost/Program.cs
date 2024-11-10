var builder = DistributedApplication.CreateBuilder(args);

// var sql = builder.AddSqlServer("sql");
// var sqldb = sql.AddDatabase("sqldb");

var apiService = builder.AddProject<Projects.DotNetAspireDemo_ApiService>("apiservice");
    // .WithReference(sqldb);

builder.AddProject<Projects.DotNetAspireDemo_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
