using Domain.Entities;

namespace Domain.Repositories;

public interface IOrderRepository 
{
    Task Create(Order order, CancellationToken cancellationToken); 
    Task<Order?> GetByNumber(string orderNumber, CancellationToken cancellationToken);
    Task<IEnumerable<Order>> GetAll(CancellationToken cancellationToken);
    
}