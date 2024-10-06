using DotnetAspireExample.ApiService.Exams.Application.Exams.DTOs;
using DotnetAspireExample.ApiService.Exams.Application.Exams.Repository;
using DotnetAspireExample.ApiService.Exams.Domain;
using MediatR;

namespace DotnetAspireExample.ApiService.Exams.Application.Exams.Queries.Handlers
{
    public class GetExamQueryHander : IRequestHandler<GetExamQuery, ExamDto>
    {
        IRepository<Exam> _repository;

        public GetExamQueryHander(IRepository<Exam> repository)
        {
            _repository = repository;
        }
        public async Task<ExamDto> Handle(GetExamQuery request, CancellationToken cancellationToken)
        {
            //var examResult = await _repository.GetAsync(request.ExamName);

            return new ExamDto(request.ExamName);

        }
    }
}
