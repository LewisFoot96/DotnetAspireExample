using DotnetAspireExample.ApiService.Exams.Application.Exams.Mapper;
using DotnetAspireExample.ApiService.Exams.Application.Exams.Repository;
using DotnetAspireExample.ApiService.Exams.Domain;
using DotnetAspireExample.Shared;
using MediatR;

namespace DotnetAspireExample.ApiService.Exams.Application.Exams.Queries.Handlers
{
    public class GetExamsQueryHander : IRequestHandler<GetExamsQuery, List<ExamDto>>
    {
        private readonly IRepository<Exam> _repository;

        public GetExamsQueryHander(IRepository<Exam> repository)
        {
            _repository = repository;
        }

        public async Task<List<ExamDto>> Handle(GetExamsQuery request, CancellationToken cancellationToken)
        {
            var examResult = await _repository.GetAllAsync();

            return examResult.Select(exam => exam?.ToExamDto()).ToList()!;
        }
    }
}