using Forgor.Security.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Forgor.Security.DataAccess;

[ExcludeFromCodeCoverage]
public static class DataAccessContainer
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>()
    }
}
