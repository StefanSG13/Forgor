using Forgor.Security.CQRS.Contracts.User.Dtos;

namespace Forgor.Security.CQRS.Contracts.User.Commands;

[ExcludeFromCodeCoverage]
public sealed class RegisterUserCommand : IRequest<IResult>
{
    public RegisterUserDto RegisterUser { get; set; }
}
