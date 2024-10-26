using DotnetAspireExample.ApiService.Exams.Application.Exams.Commands;
using DotnetAspireExample.ApiService.Exams.Application.Exams.Queries;
using DotnetAspireExample.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        private static async Task<IResult> GetExams(IMediator sender)
        {
            var result = await sender.Send(new GetExamsQuery());

            return
                TypedResults.Ok(result);
        }

        public static async Task<IResult> CreateExam([FromBody]ExamDto exam, IMediator sender)
        {
            var result = await sender.Send(new CreateExamCommand(exam));

            return
                TypedResults.NoContent();
        }
    }
}
