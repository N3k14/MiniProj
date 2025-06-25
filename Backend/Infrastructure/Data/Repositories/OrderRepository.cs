using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class OrderRepository(SaleDbContext saleDbContext) : IOrderRepository
{
    public async Task CreateAsync(Order order, CancellationToken cancellationToken)
    {
        await saleDbContext.AddAsync(order, cancellationToken);
        await saleDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Order?> GetByIdAsync(int orderId, CancellationToken cancellationToken)
    {
        var order = await saleDbContext.Orders
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == orderId, cancellationToken);
        
        return order;
    }

    public async Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken)
    {
        var orders = await saleDbContext.Orders
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        
        return orders;
    }
}