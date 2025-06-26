using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using WebApi.Endpoints;

namespace WebApi.Extensions;

public static class MiddlewareExtensions 
{
    public static void UseMapEndpoints(
        this WebApplication app,
        string? prefix = null)
    {
        IEnumerable<IEndpoint> endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();

        IEndpointRouteBuilder builder = prefix is null ? app : app.MapGroup(prefix);
        
        foreach (IEndpoint endpoint in endpoints)
        {
            endpoint.MapEndpoint(builder);
        }
    }

    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        var scope = app.ApplicationServices.CreateScope();
        
        using var db = scope.ServiceProvider.GetRequiredService<SaleDbContext>();
        
        db.Database.Migrate();
    }
}