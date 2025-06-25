using Application.Abstractions;
using Application.Requests;
using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Services;

public class OrderService(IOrderRepository orderRepository, INumberGenerator numberGenerator) : IOrderService
{
    public async Task<bool> CreateOrder(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        var number = numberGenerator.Generate(request.CargoPickupDate);
        
        var locationSender = Location.Create(request.CitySender, request.AddressSender);
        var locationReceiver = Location.Create(request.CityReceiver, request.AddressReceiver);
        
        var order = Order.Create(
            number,
            locationSender,
            locationReceiver,
            request.CargoWeightInKg,
            request.CargoPickupDate);

        await orderRepository.CreateAsync(order, cancellationToken);

        return true;
    }

    public async Task<Order> GetOrderById(int orderId, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetByIdAsync(orderId, cancellationToken);
        
        if (order is null)
            throw new Exception("Заказ не найден");
        
        return order;
    }

    public async Task<IEnumerable<Order>> GetOrders(CancellationToken cancellationToken)
    {
        var orders = await orderRepository.GetAllAsync(cancellationToken);
        
        return orders;
    }
}