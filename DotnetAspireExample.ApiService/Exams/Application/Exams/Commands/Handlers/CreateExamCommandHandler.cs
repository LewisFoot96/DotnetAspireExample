using DotnetAspireExample.ApiService.Exams.Application.Exams.Repository;
using DotnetAspireExample.ApiService.Exams.Domain;
using MediatR;

namespace DotnetAspireExample.ApiService.Exams.Application.Exams.Commands.Handlers
{
    public class CreateExamCommandHandler : IRequestHandler<CreateExamCommand, string>
    {
        private IRepository<Exam> _examRepository;

        public CreateExamCommandHandler(IRepository<Exam> repository)
        {
            _examRepository = repository;
        }

        async Task<string> IRequestHandler<CreateExamCommand, string>.Handle(CreateExamCommand request, CancellationToken cancellationToken)
        {
            var exam = new Exam
            {
                ExamName = request.Exam.ExamName
            };
            var result = await _examRepository.CreateAsync(exam, cancellationToken);
            return "Lewis";
        }
    }
}
