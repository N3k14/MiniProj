using Application;
using Infrastructure;
using WebApi;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddWebApiServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseCors();
app.MapHealthChecks("/health");  
app.UseMapEndpoints("api/");

app.Run();
