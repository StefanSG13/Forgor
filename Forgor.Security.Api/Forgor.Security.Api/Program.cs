using Forgor.Security.Api.Extensions;
using Forgor.Security.CQRS.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCQRSServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiSwaggerDocument();

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
app.UseApiEndpoints();

await app.RunAsync().ConfigureAwait(false);
