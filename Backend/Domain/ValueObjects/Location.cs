using Domain.Errors;
using SharedKernel;

namespace Domain.ValueObjects;

public class Location 
{
    public string City { get; private set; }
    public string Address { get; private set; }

    private Location(string city, string address)
    {
        City = city;
        Address = address;
    }

    public static Result<Location> Create(string city, string address)
    {
        if (string.IsNullOrEmpty(city))
            return Result.Failure<Location>(LocationErrors.AbsentCity());
        
        if (string.IsNullOrEmpty(address))
            return Result.Failure<Location>(LocationErrors.AbsentAddress());
        
        return new Location(city, address);
    }
    
}