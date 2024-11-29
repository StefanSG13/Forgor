using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using NJsonSchema;
using NJsonSchema.Generation;

namespace Forgor.Security.Api.Extensions;

[ExcludeFromCodeCoverage]
internal static class OpenApiExtensions
{
    public static IServiceCollection AddApiSwaggerDocument(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Forgor.Security", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme.",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
            });
        });

        services.AddOpenApiDocument((config, services) =>
        {
            var jsonOptions = services.GetRequiredService<IOptions<JsonOptions>>();
            config.SchemaSettings = new SystemTextJsonSchemaGeneratorSettings
            {
                SchemaType = SchemaType.OpenApi3,
                SerializerOptions = jsonOptions.Value.SerializerOptions,
            };

            config.DocumentName = "v1";
            config.Title = "Forgor.Security";
            config.Version = "v1";
        });

        return services;
    }
}
