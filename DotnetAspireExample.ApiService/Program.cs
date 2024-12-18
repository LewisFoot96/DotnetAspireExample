using DotnetAspireExample.ApiService.Exams;
using DotnetAspireExample.ApiService.Exams.Application.Exams.Repository;
using DotnetAspireExample.ApiService.Exams.Domain;
using DotnetAspireExample.ApiService.Exams.Endpoints;
using DotnetAspireExample.ApiService.Exams.Infrastrucutre.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();
builder.Services.AddOpenTelemetry()
           .WithMetrics(metrics =>
           {
               metrics.AddMeter(DiagnosticsConfig.Meter.Name);
           }
           )
           .WithTracing(tracing =>
           {
               tracing.AddSource(DiagnosticsConfig.ActivitySource.Name);
           });


builder.AddRedisOutputCache("cache");

//builder.AddSqlServerClient("AZURE_SQL_CONNECTIONSTRING");
builder.AddSqlServerClient("myConnection");

// Add services to the container.
builder.Services.AddProblemDetails();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Exam).Assembly));

builder.Services.AddScoped<IRepository<Exam>, ExamDatabaseRepository>();

const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(myAllowSpecificOrigins,
                          policy =>
                          {
                              policy.WithOrigins("https://localhost:7449")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod()
                                                  .AllowAnyOrigin()
                                                  //.AllowCredentials()
                                                  .SetIsOriginAllowed(_ => true);
                          });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.UseCors();

app.UseOutputCache();

app.MapDefaultEndpoints();

app.MapExamEndpoints();

app.Run();

