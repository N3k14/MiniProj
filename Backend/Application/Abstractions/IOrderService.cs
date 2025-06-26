using Application.Requests;
using Domain.Entities;
using SharedKernel;

namespace Application.Abstractions;

public interface IOrderService 
{
    Task<Result> CreateOrder(CreateOrderRequest order, CancellationToken cancellationToken);
    Task<Result<Order>> GetOrderById(int orderId, CancellationToken cancellationToken);
    Task<Result<IEnumerable<Order>>> GetOrders(CancellationToken cancellationToken);
}