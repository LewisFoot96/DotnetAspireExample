using DotnetAspireExample.ApiService.Application.Exams.DTOs;
using MediatR;

namespace DotnetAspireExample.ApiService.Application.Exams.Queries
{
    public record GetExamQuery(string ExamName) : IRequest<ExamDto>;
}
