using Application.Requests;
using Domain.Entities;

namespace Application.Abstractions;

public interface IOrderService 
{
    Task<bool> CreateOrder(CreateOrderRequest order, CancellationToken cancellationToken);
    Task<Order> GetOrderById(int orderId, CancellationToken cancellationToken);
    Task<IEnumerable<Order>> GetOrders(CancellationToken cancellationToken);
}