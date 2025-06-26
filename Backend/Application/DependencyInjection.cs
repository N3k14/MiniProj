using Application.Abstractions;
using Application.Services;
using Application.Validations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection 
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IOrderService, OrderService>();
        services.AddValidatorsFromAssemblyContaining<OrderRequestValidator>();
        return services;
    }
}