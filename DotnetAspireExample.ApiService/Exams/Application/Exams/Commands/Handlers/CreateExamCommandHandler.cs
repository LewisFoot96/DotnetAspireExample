using DotnetAspireExample.ApiService.Exams.Application.Exams.Repository;
using DotnetAspireExample.ApiService.Exams.Domain;
using MediatR;

namespace DotnetAspireExample.ApiService.Exams.Application.Exams.Commands.Handlers
{
    public class CreateExamCommandHandler(IRepository<Exam> repository) : IRequestHandler<CreateExamCommand, string>
    {
        public async Task<string> Handle(CreateExamCommand request, CancellationToken cancellationToken)
        {
            var exam = new Exam
            {
                ExamName = request.Exam.ExamName
            };
            var result = await repository.CreateAsync(exam, cancellationToken);
            return result.ExamName;
        }
    }
}