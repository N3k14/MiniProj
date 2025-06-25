using System.Text.RegularExpressions;
using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Order : EntityBase
{
    public string Number { get; private set; }
    public Location LocationSender { get; private set; }
    public Location LocationReceiver { get; private set; }
    public decimal CargoWeightInKg { get; private set; }
    public DateOnly CargoPickupDate { get; private set; }
    
    // Для EF Core
    private Order() { }
    
    private Order(
        string number,
        Location locationSender,
        Location locationReceiver,
        decimal cargoWeightInKg,
        DateOnly cargoPickupDate)
    {
        Number = number;
        LocationSender = locationSender;
        LocationReceiver = locationReceiver;
        CargoWeightInKg = cargoWeightInKg;
        CargoPickupDate = cargoPickupDate;
    }

    public static Order Create(
        string number,
        Location locationSender,
        Location locationReceiver,
        decimal cargoWeightInKg,
        DateOnly cargoPickupDateTime)
    {
        ArgumentNullException.ThrowIfNull(number);
        ArgumentNullException.ThrowIfNull(locationSender);
        ArgumentNullException.ThrowIfNull(locationReceiver);
        
        if (cargoWeightInKg <= 0)
            throw new ArgumentException("Вес груза не может быть меньше нуля");
        
        if (!IsNumberCorrect(number))
            throw new ArgumentException("Неверный формат номера");

        return new Order(number, locationSender, locationReceiver, cargoWeightInKg, cargoPickupDateTime);
    }

    private static bool IsNumberCorrect(string number)
    {
        return Regex.IsMatch(number, @"^ORD-\d{6}-\d{4}$");
    }
}