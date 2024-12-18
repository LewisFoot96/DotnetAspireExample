var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var sql = builder.AddSqlServer("sql");
var sqldb = sql.AddDatabase("sqldb");

var apiService = builder.AddProject<Projects.DotnetAspireExample_ApiService>("apiservice")
    .WithReference(cache)
    .WithReference(sqldb); //Reference to the SQL server database

builder.AddProject<Projects.DotnetAspireExample_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService);

builder.AddNpmApp("testreact", "../testlewisreact.client")
    .WithReference(apiService)
    .WithReference(cache);

builder.AddProject<Projects.DotnetAspireExample_FunctionApp>("dotnetaspireexample-functionapp")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();

//https://learn.microsoft.com/en-us/dotnet/aspire/get-started/aspire-overview - Aspire overview
