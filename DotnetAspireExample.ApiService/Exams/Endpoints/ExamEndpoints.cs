using DotnetAspireExample.ApiService.Exams.Application.Exams.Commands;
using DotnetAspireExample.ApiService.Exams.Application.Exams.Queries;
using MediatR;

namespace DotnetAspireExample.ApiService.Exams.Endpoints
{
    public static class ExamEndpoints
    {
        public static void MapExamEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("exam");
            //Minimal apis use method injection
            group.MapPost("", CreateExam);

            group.MapGet("{name}", GetExam);
        }

        private static async Task<IResult> GetExam(string name, IMediator sender)
        {
            var result = await sender.Send(new GetExamQuery(name));

            return
                TypedResults.Ok(result);
        }

        public static async Task<IResult> CreateExam(string examName, IMediator sender)
        {
            var result = await sender.Send(new CreateExamCommand(examName));

            return
                TypedResults.NoContent();
        }
    }
}
