using DotnetAspireExample.ApiService.Exams.Application.Exams.Mapper;
using DotnetAspireExample.ApiService.Exams.Application.Exams.Repository;
using DotnetAspireExample.ApiService.Exams.Domain;
using DotnetAspireExample.Shared;
using MediatR;

namespace DotnetAspireExample.ApiService.Exams.Application.Exams.Queries.Handlers
{
    public class GetExamsQueryHander(IRepository<Exam> repository) : IRequestHandler<GetExamsQuery, List<ExamDto>>
    {
        public async Task<List<ExamDto>> Handle(GetExamsQuery request, CancellationToken cancellationToken)
        {
            var examResult = await repository.GetAllAsync();

            return examResult.Select(exam => exam?.ToExamDto()).ToList()!;
        }
    }
}