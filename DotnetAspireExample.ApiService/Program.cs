using DotnetAspireExample.ApiService.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

builder.AddSqlServerClient("Server=tcp:sql-server-test-aspire.database.windows.net,1433;Initial Catalog=AspireTestDatabase;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication=\"Active Directory Default\";");

// Add services to the container.
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();



app.MapDefaultEndpoints();

app.MapExamEndpoints();

app.Run();

