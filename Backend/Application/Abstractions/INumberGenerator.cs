namespace Application.Abstractions;

public interface INumberGenerator 
{
    string Generate(DateOnly date);
}