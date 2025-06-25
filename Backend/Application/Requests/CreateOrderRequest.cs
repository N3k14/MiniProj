namespace Application.Requests;

public record CreateOrderRequest(
    string CitySender,
    string AddressSender,
    string CityReceiver,
    string AddressReceiver,
    decimal CargoWeightInKg,
    DateOnly CargoPickupDate);