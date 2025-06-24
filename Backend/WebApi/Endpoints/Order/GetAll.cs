using Application.Abstractions;

namespace WebApi.Endpoints.Order;

public class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("orders", async (IOrderService orderService, CancellationToken cancellationToken) =>
        {
            var response = await orderService.GetOrders(cancellationToken);
            return response;
        })
        .WithTags(Tags.Orders);
    }
}