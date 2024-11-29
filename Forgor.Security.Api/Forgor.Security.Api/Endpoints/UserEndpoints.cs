using Forgor.Security.CQRS.Contracts.User.Commands;
using Forgor.Security.CQRS.Contracts.User.Quries;
using Microsoft.AspNetCore.Mvc;

namespace Forgor.Security.Api.Endpoints;

[ExcludeFromCodeCoverage]
internal static class UserEndpoints
{
    internal static WebApplication AddUserEnpoints(this WebApplication application)
    {
        application.MapPost($"/{RouteNamesConstants.User}/register", RegisterUserAsync)
            .AllowAnonymous()
            .Produces(StatusCodes.Status200OK)
            .WithTags(nameof(UserEndpoints))
            .WithName(nameof(RegisterUserAsync))
            .WithOpenApi();

        application.MapPost($"/{RouteNamesConstants.User}/login", LoginUserAsync)
            .AllowAnonymous()
            .Produces(StatusCodes.Status200OK)
            .WithTags(nameof(UserEndpoints))
            .WithName(nameof(LoginUserAsync))
            .WithOpenApi();

        application.MapPost($"/{RouteNamesConstants.User}/loginDoi", LoginUserAsync)
            .RequireAuthorization()
            .Produces(StatusCodes.Status200OK)
            .WithTags(nameof(UserEndpoints))
            .WithName(nameof(LoginUserAsync) + "Doi")
            .WithOpenApi();

        return application;
    }

    private static async Task<IResult> RegisterUserAsync(IMediator mediator, [FromBody] RegisterUserCommand request, CancellationToken cancellationToken)
        => await mediator.Send(request, cancellationToken).ConfigureAwait(false);

    private static async Task<IResult> LoginUserAsync(IMediator mediator, [FromBody] LoginUserQuery request, CancellationToken cancellationToken)
        => await mediator.Send(request, cancellationToken).ConfigureAwait(false);
}
