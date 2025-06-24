using System.Text.RegularExpressions;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Order 
{
    public string Number { get; private set; }
    public Location LocationSender { get; private set; }
    public Location LocationReceiver { get; private set; }
    public decimal CargoWeightInKg { get; private set; }
    public DateTime CargoPickupDateTime { get; private set; }
    
    // Для EF Core
    private Order() { }
    
    private Order(
        string number,
        Location locationSender,
        Location locationReceiver,
        decimal cargoWeight,
        DateTime cargoPickupDateTime)
    {
        Number = number;
        LocationSender = locationSender;
        LocationReceiver = locationReceiver;
        CargoWeightInKg = cargoWeight;
        CargoPickupDateTime = cargoPickupDateTime;
    }

    public static Order Create(
        string number,
        Location locationSender,
        Location locationReceiver,
        decimal cargoWeight,
        DateTime cargoPickupDateTime)
    {
        ArgumentNullException.ThrowIfNull(number);
        ArgumentNullException.ThrowIfNull(locationSender);
        ArgumentNullException.ThrowIfNull(locationReceiver);
        
        if (cargoWeight <= 0)
            throw new ArgumentException("Вес груза не может быть меньше нуля");
        
        if (!IsNumberCorrect(number))
            throw new ArgumentException("Неверный формат номера");

        return new Order(number, locationSender, locationReceiver, cargoWeight, cargoPickupDateTime);
    }

    public static bool IsNumberCorrect(string number)
    {
        if (Regex.IsMatch(number, @"XXXX-XXXX"))
            return true;
        
        return false;
    }
}