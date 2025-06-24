using Application.Abstractions;
using Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints.Order;

public class Create : IEndpoint 
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("orders", async (
            [FromBody] CreateOrderRequest request,
            IOrderService orderService,
            CancellationToken cancellationToken) => 
        {
            var response = await orderService.CreateOrder(request, cancellationToken);
            return response;
        })
        .WithTags(Tags.Orders);
    }
}