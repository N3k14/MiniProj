using Application.Abstractions;

namespace Infrastructure.Services;

public class NumberGenerator : INumberGenerator
{
    public string Generate(DateOnly date)
    {
        var random = new Random();
        return $"ORD-{date:ddMMyy}-{random.Next(1000, 9999)}";
    }
}