using FluentValidation.Results;
using MediatR;

namespace DoadorOnline.Application;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ValidationResult>
{
    public async Task<ValidationResult> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
