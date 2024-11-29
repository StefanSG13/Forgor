using Forgor.Security.CQRS.Contracts.User.Dtos;

namespace Forgor.Security.CQRS.Contracts.User.Quries;

[ExcludeFromCodeCoverage]
public class LoginUserQuery : IRequest<IResult>
{
    public LoginUserDto LoginUser { get; set; }
}
