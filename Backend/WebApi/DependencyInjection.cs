using System.Reflection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebApi.Endpoints;

namespace WebApi;

public static class DependencyInjection 
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddMapEndpoints();

        return services;
    }

    private static IServiceCollection AddMapEndpoints(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        
        var serviceDescriptors = assembly.DefinedTypes
            .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                           type.IsAssignableTo(typeof(IEndpoint)))
            .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))
            .ToArray();
        
        services.TryAddEnumerable(serviceDescriptors);
        
        return services;
    }
}