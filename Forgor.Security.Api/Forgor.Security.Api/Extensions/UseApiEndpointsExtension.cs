using Forgor.Security.Api.Endpoints;

namespace Forgor.Security.Api.Extensions;

[ExcludeFromCodeCoverage]
internal static class UseApiEndpointsExtension
{
    public static WebApplication UseApiEndpoints(this WebApplication application)
    {
        application.AddUserEnpoints();

        return application;
    }
}
