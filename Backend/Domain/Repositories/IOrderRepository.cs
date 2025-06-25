using Domain.Entities;

namespace Domain.Repositories;

public interface IOrderRepository 
{
    Task CreateAsync(Order order, CancellationToken cancellationToken); 
    Task<Order?> GetByIdAsync(int orderId, CancellationToken cancellationToken);
    Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken);
}