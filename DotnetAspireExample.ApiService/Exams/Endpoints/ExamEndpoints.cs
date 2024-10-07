using DotnetAspireExample.ApiService.Exams.Application.Exams.Commands;
using DotnetAspireExample.ApiService.Exams.Application.Exams.DTOs;
using DotnetAspireExample.ApiService.Exams.Application.Exams.Queries;
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
            group.MapPost("/", CreateExam);

            group.MapGet("{name}", GetExam);
        }

        private static async Task<IResult> GetExam(string name, IMediator sender)
        {
            var result = await sender.Send(new GetExamQuery(name));

            return
                TypedResults.Ok(result);
        }

        public static async Task<IResult> CreateExam([FromBody]CreateExamDto exam, IMediator sender)
        {
            var result = await sender.Send(new CreateExamCommand(exam));

            return
                TypedResults.NoContent();
        }
    }
}
