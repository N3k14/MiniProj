using Application.Abstractions;
using Application.Requests;
using Domain;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services;

public class OrderService(IOrderRepository orderRepository) : IOrderService
{
    public Task<bool> CreateOrder(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        //todo генерация номера заказа
        
        //todo создание объектов класса Location
        
        //todo создание сущности Order и сохранение ее в бд через репозиторий
        
        return Task.FromResult(true);
    }

    public async Task<Order> GetOrderByNumber(string orderNumber, CancellationToken cancellationToken)
    {
        if (!Order.IsNumberCorrect(orderNumber))
            throw new ArgumentException("Неверный формат номера");
        
        var order = await orderRepository.GetByNumber(orderNumber, cancellationToken);
        
        if (order is null)
            throw new Exception("Заказ не найден");
        
        return order;
    }

    public async Task<IEnumerable<Order>> GetOrders(CancellationToken cancellationToken)
    {
        var orders = await orderRepository.GetAll(cancellationToken);
        
        return orders;
    }
}