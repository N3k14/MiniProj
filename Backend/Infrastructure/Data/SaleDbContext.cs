using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class SaleDbContext(DbContextOptions<SaleDbContext> options) : DbContext(options)
{
    DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(orderBuilder =>
        {
            orderBuilder.ToTable("order");
            orderBuilder.HasKey(o => o.Number);
            orderBuilder.ComplexProperty(o => o.LocationSender,
                locationSenderBuilder =>
                {
                    locationSenderBuilder.Property(ls => ls.City).HasColumnName("sender_city");
                    locationSenderBuilder.Property(ls => ls.Address).HasColumnName("sender_address");
                });
            orderBuilder.ComplexProperty(o => o.LocationReceiver,
                locationReceiverBuilder =>
                {
                    locationReceiverBuilder.Property(ls => ls.City).HasColumnName("receiver_city");
                    locationReceiverBuilder.Property(ls => ls.Address).HasColumnName("receiver_address");
                });
            orderBuilder.Property(o => o.CargoWeightInKg);
            orderBuilder.Property(o => o.CargoPickupDateTime);
        });
        
        modelBuilder.HasDefaultSchema(Schemas.Sales);
    }
}