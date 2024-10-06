using DotnetAspireExample.ApiService;
using DotnetAspireExample.ApiService.Exams.Application.Exams.Repository;
using DotnetAspireExample.ApiService.Exams.Domain;
using DotnetAspireExample.ApiService.Exams.Endpoints;
using DotnetAspireExample.ApiService.Exams.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

builder.AddSqlServerClient("AZURE_SQL_CONNECTIONSTRING");

// Add services to the container.
builder.Services.AddProblemDetails();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Exam).Assembly));

builder.Services.AddScoped<IRepository<Exam>, ExamDatabaseRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.MapDefaultEndpoints();

app.MapExamEndpoints();

app.Run();

