using Application.Requests;
using Domain;
using Domain.Entities;

namespace Application.Abstractions;

public interface IOrderService 
{
    // todo Заменить bool на паттерн Result
    Task<bool> CreateOrder(CreateOrderRequest order, CancellationToken cancellationToken);
    Task<Order> GetOrderByNumber(string orderNumber, CancellationToken cancellationToken);
    Task<IEnumerable<Order>> GetOrders(CancellationToken cancellationToken);
}