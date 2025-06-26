using SharedKernel;

namespace Domain.Errors;

public static class LocationErrors 
{
    public static Error AbsentCity() => Error.Problem(
        "Location.AbsentCity",
        "Отсутствует название города при инициализации объекта Location");
    
    public static Error AbsentAddress() => Error.Problem(
        "Location.AbsentAddress",
        "Отсутствует адрес при инициализации объекта Location");

}