using Application.Abstractions;
using WebApi.Extensions;

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
            var result = await orderService.GetOrderById(id, cancellationToken);
            return result.Match(Results.Ok, ProblemResults.Problem);
        })
        .WithTags(Tags.Orders);
    }
}