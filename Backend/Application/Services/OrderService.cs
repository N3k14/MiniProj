using Application.Abstractions;
using Application.Requests;
using Domain.Entities;
using Domain.Errors;
using Domain.Repositories;
using Domain.ValueObjects;
using SharedKernel;

namespace Application.Services;

public class OrderService(IOrderRepository orderRepository, INumberGenerator numberGenerator) : IOrderService
{
    public async Task<Result> CreateOrder(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        var number = numberGenerator.Generate(request.CargoPickupDate);
        
        var locationSender = Location.Create(request.CitySender, request.AddressSender);
        if (locationSender.IsFailure)
            return locationSender;
        
        var locationReceiver = Location.Create(request.CityReceiver, request.AddressReceiver);
        if (locationReceiver.IsFailure)
            return locationReceiver;
        
        var order = Order.Create(
            number,
            locationSender.Value,
            locationReceiver.Value,
            request.CargoWeightInKg,
            request.CargoPickupDate);
        if (order.IsFailure)
            return order;

        await orderRepository.CreateAsync(order.Value, cancellationToken);

        return Result.Success();
    }

    public async Task<Result<Order>> GetOrderById(int orderId, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetByIdAsync(orderId, cancellationToken);
        
        if (order is null)
            return Result.Failure<Order>(OrderErrors.NotFound(orderId));
        
        return Result.Success(order);
    }

    public async Task<Result<IEnumerable<Order>>> GetOrders(CancellationToken cancellationToken)
    {
        var orders = await orderRepository.GetAllAsync(cancellationToken);
        
        return Result.Success(orders);
    }
}