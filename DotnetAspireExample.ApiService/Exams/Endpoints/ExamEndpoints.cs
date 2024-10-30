using DotnetAspireExample.ApiService.Exams.Application.Exams.Commands;
using DotnetAspireExample.ApiService.Exams.Application.Exams.Queries;
using DotnetAspireExample.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace DotnetAspireExample.ApiService.Exams.Endpoints
{
    public static class ExamEndpoints
    {
        public static void MapExamEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("exam");
            //Minimal apis use method injection
            group.MapPost("/", CreateExam).RequireCors("_myAllowSpecificOrigins"); ;

            group.MapGet("/", GetExams).RequireCors("_myAllowSpecificOrigins");
        }

        [OutputCache(Duration = 10)]
        private static async Task<IResult> GetExams(IMediator sender)
        {
            var childActivity = DiagnosticsConfig.ActivitySource.StartActivity("GetExamsTest");

            var result = await sender.Send(new GetExamsQuery());

            childActivity?.AddEvent(new("Result returned"));

            childActivity?.SetTag("exam count", result.Count);

            childActivity?.Stop();


            return
                TypedResults.Ok(result);

        }

        public static async Task<IResult> CreateExam([FromBody] ExamDto exam, IMediator sender)
        {
            var result = await sender.Send(new CreateExamCommand(exam));

            DiagnosticsConfig.SalesCounter.Add(1);
            DiagnosticsConfig.SalesCounter.Add(1, tag: new KeyValuePair<string, object>("ExamName", exam.ExamName));

            return
                TypedResults.NoContent();
        }
    }
}
