using Forgor.Security.CQRS.Contracts.User.Dtos;

namespace Forgor.Security.CQRS.Contracts.User.Commands;

[ExcludeFromCodeCoverage]
public sealed class ChangePasswordCommand : IRequest<IResult>
{
    public ChangePasswordDto ChangePassword { get; set; }
}
