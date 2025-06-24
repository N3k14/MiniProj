namespace Domain.ValueObjects;

public class Location 
{
    public string City { get; private set; }
    public string Address { get; private set; }
    
    // todo сделать проверки для входных данных
}