using Domain;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Data.Repositories;

public class OrderRepository : IOrderRepository
{
    public Task Create(Order order, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Order?> GetByNumber(string orderNumber, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Order>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}