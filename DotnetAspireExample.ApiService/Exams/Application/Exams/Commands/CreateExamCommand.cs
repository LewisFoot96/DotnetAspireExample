using MediatR;

namespace DotnetAspireExample.ApiService.Exams.Application.Exams.Commands
{
    public record CreateExamCommand(string examName) : IRequest<string>;
}
