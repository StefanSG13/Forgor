using Forgor.Security.Api.Extensions;
using Forgor.Security.CQRS.Handlers;
using Forgor.Security.DataAccess;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSecurityServices(builder.Configuration);

builder.Services.AddCQRSServices();
builder.Services.AddDataAccessServices();

builder.Services.AddApiSwaggerDocument();
builder.Services.AddEndpointsApiExplorer();

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseApiEndpoints();

await app.RunAsync().ConfigureAwait(false);
