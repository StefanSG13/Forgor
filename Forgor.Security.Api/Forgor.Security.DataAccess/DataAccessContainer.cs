using Forgor.Security.DataAccess.Repositories;
using Forgor.Security.DataAccess.SqlClients;
using Forgor.Security.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Forgor.Security.DataAccess;

[ExcludeFromCodeCoverage]
public static class DataAccessContainer
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
    {
        services.AddScoped<IPostgresSqlClient, PostgresSqlClient>();

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
