using Application.Abstractions;

namespace WebApi.Endpoints.Order;

public class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("orders/{id:int}", async (
            int id,
            IOrderService orderService,
            CancellationToken cancellationToken) =>
        {
            var response = await orderService.GetOrderById(id, cancellationToken);
            return response;
        })
        .WithTags(Tags.Orders);
    }
}