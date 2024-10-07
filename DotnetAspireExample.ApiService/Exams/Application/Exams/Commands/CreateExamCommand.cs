using DotnetAspireExample.ApiService.Exams.Application.Exams.DTOs;
using MediatR;

namespace DotnetAspireExample.ApiService.Exams.Application.Exams.Commands
{
    public record CreateExamCommand(CreateExamDto Exam) : IRequest<string>;
}
