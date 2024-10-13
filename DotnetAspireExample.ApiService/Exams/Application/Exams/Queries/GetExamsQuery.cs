using DotnetAspireExample.ApiService.Exams.Application.Exams.DTOs;
using MediatR;

namespace DotnetAspireExample.ApiService.Exams.Application.Exams.Queries
{
    public record GetExamsQuery(string ExamName) : IRequest<List<ExamDto>>;
}
