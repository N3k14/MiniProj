using System.Text.RegularExpressions;
using Domain.Common;
using Domain.Errors;
using Domain.Extensions;
using Domain.ValueObjects;
using SharedKernel;

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

    public static Result<Order> Create(
        string number,
        Location locationSender,
        Location locationReceiver,
        decimal cargoWeightInKg,
        DateOnly cargoPickupDateTime)
    {
        if (!cargoWeightInKg.IsPositive())
            return Result.Failure<Order>(OrderErrors.IncorrectCargoWeight());
        
        if (!IsNumberCorrect(number))
            return Result.Failure<Order>(OrderErrors.IncorrectNumberPattern());

        return new Order(number, locationSender, locationReceiver, cargoWeightInKg, cargoPickupDateTime);
    }

    private static bool IsNumberCorrect(string number)
    {
        return Regex.IsMatch(number, @"^ORD-\d{6}-\d{4}$");
    }
}