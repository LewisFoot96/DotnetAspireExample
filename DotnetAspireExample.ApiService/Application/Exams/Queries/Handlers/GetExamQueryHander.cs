using DotnetAspireExample.ApiService.Application.Exams.DTOs;
using MediatR;

namespace DotnetAspireExample.ApiService.Application.Exams.Queries.Handlers
{
    public class GetExamQueryHander : IRequestHandler<GetExamQuery, ExamDto>
    {
        public Task<ExamDto> Handle(GetExamQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
