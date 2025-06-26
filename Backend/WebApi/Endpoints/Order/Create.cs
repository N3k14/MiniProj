using Application.Abstractions;
using Application.Requests;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;

namespace WebApi.Endpoints.Order;

public class Create : IEndpoint 
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("orders", async (
            [FromBody] CreateOrderRequest request, 
            IValidator<CreateOrderRequest> validator,
            IOrderService orderService,
            CancellationToken cancellationToken) => 
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }
            
            var result = await orderService.CreateOrder(request, cancellationToken);
            return result.Match(Results.Created, ProblemResults.Problem);
        })
        .WithTags(Tags.Orders);
    }
}