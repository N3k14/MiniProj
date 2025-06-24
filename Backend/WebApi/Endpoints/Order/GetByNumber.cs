using Application.Abstractions;

namespace WebApi.Endpoints.Order;

public class GetByNumber : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("orders/{number}", async (
            string number,
            IOrderService orderService,
            CancellationToken cancellationToken) =>
        {
            var response = await orderService.GetOrderByNumber(number, cancellationToken);
            return response;
        })
        .WithTags(Tags.Orders);
    }
}