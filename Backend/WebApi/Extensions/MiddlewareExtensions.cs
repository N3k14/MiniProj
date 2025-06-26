using WebApi.Endpoints;

namespace WebApi.Extensions;

public static class MiddlewareExtensions 
{
    public static IApplicationBuilder UseMapEndpoints(
        this WebApplication app,
        string? prefix = null)
    {
        IEnumerable<IEndpoint> endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();

        IEndpointRouteBuilder builder = prefix is null ? app : app.MapGroup(prefix);
        
        foreach (IEndpoint endpoint in endpoints)
        {
            endpoint.MapEndpoint(builder);
        }

        return app;
    }
}