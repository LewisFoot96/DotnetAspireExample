using MediatR;

namespace DotnetAspireExample.ApiService.Application.Exams.Commands.Handlers
{
    public class CreateExamCommandHandler : IRequestHandler<CreateExamCommand, string>
    {
        Task<string> IRequestHandler<CreateExamCommand, string>.Handle(CreateExamCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
