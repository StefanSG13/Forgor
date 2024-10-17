using Forgor.Security.CQRS.Contracts.User.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Forgor.Security.Api.Endpoints;

[ExcludeFromCodeCoverage]
internal static class UserEndpoints
{
    internal static WebApplication AddUserEnpoints(this  WebApplication application)
    {
        application.MapPost($"/{RouteNamesConstants.User}/register", RegisterUserAsync)
            .Produces(StatusCodes.Status200OK)
            .WithTags(nameof(UserEndpoints))
            .WithName(nameof(RegisterUserAsync))
            .WithOpenApi();

        return application;
    }

    private static async Task<IResult> RegisterUserAsync(IMediator mediator, [FromBody] RegisterUserCommand request, CancellationToken cancellationToken)
        => await mediator.Send(request, cancellationToken).ConfigureAwait(false);
}
