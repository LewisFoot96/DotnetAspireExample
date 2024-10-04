using MediatR;

namespace DotnetAspireExample.ApiService.Application.Exams.Commands
{
    public record  CreateExamCommand(string examName) : IRequest<string>;
}
