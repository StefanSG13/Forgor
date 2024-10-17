using Forgor.Security.CQRS.Contracts.User.Dtos;

namespace Forgor.Security.CQRS.Contracts.User.Quries;

[ExcludeFromCodeCoverage]
public class ForgotPasswordQuery : IRequest<IResult>
{
    public ForgotPasswordDto ForgotPassword { get; set; }
}
