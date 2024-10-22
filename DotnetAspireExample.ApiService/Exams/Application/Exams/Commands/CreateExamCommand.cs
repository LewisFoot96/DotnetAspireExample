using DotnetAspireExample.Shared;
using MediatR;

namespace DotnetAspireExample.ApiService.Exams.Application.Exams.Commands
{
    public record CreateExamCommand(ExamDto Exam) : IRequest<string>;
}
