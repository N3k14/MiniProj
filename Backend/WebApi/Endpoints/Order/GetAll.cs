using Application.Abstractions;

namespace WebApi.Endpoints.Order;

public class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("orders", async (IOrderService orderService, CancellationToken cancellationToken) => 
        {
            var response = await orderService.GetOrders(cancellationToken);
            return Results.Ok(response.Value);
        })
        .WithTags(Tags.Orders);
    }
}