using DotnetAspireExample.ApiService.Application.Exams.Commands;
using MediatR;

namespace DotnetAspireExample.ApiService.Endpoints
{
    public static class ExamEndpoints
    {
        public static void MapExamEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("exam");
            //Minimal apis use method injection
            group.MapPost("", CreateExam);

            //group.MapGet("{id}", GetWeather);
        }

        public static async Task<IResult> CreateExam(string examName, IMediator sender)
        {
            var result = await sender.Send(new CreateExamCommand(examName));

            return
                TypedResults.NoContent();
        }
    }
}
