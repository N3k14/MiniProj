namespace Domain.Extensions;

public static class DecimalExtensions 
{
    public static bool IsPositive(this decimal number) => number > 0;
}
