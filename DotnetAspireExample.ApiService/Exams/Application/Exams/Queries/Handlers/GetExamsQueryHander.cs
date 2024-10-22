using DotnetAspireExample.ApiService.Exams.Application.Exams.Repository;
using DotnetAspireExample.ApiService.Exams.Domain;
using DotnetAspireExample.Shared;
using MediatR;

namespace DotnetAspireExample.ApiService.Exams.Application.Exams.Queries.Handlers
{
    public class GetExamsQueryHander : IRequestHandler<GetExamsQuery, List<ExamDto>>
    {
        IRepository<Exam> _repository;

        public GetExamsQueryHander(IRepository<Exam> repository)
        {
            _repository = repository;
        }
        public async Task<List<ExamDto>> Handle(GetExamsQuery request, CancellationToken cancellationToken)
        {
             var examResult = await _repository.GetAsync(request.ExamName);

            return new List<ExamDto>
            { 
                new(request.ExamName, 10)
            };

        }
    }
}
