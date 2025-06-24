namespace Application.Requests;

public record CreateOrderRequest(
    string CitySender,
    string CityReceiver,
    string AddressSender,
    string AddressReceiver,
    decimal CargoWeight,
    DateTime CargoPickupDateTime);