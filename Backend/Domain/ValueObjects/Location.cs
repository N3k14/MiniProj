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

    public static Location Create(string city, string address)
    {
        ArgumentNullException.ThrowIfNull(city);
        ArgumentNullException.ThrowIfNull(address);
        
        return new Location(city, address);
    }
    
}