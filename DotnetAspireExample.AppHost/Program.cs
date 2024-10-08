using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");


var sql = builder.AddSqlServer("sql");
var sqldb = sql.AddDatabase("sqldb");

var apiService = builder.AddProject<Projects.DotnetAspireExample_ApiService>("apiservice")
    .WithReference(sqldb); //Refernce to the SQL server database

builder.AddProject<Projects.DotnetAspireExample_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService);

builder.AddNpmApp("my-app", "C:\\Users\\lfoot\\source\\repos\\DotnetAspireExample\\my-app")
    .WithReference(apiService);

builder.Build().Run();
