using SharedKernel;

namespace Domain.Errors;

public class OrderErrors 
{
    public static Error IncorrectCargoWeight() => Error.Problem(
        "Order.IncorrectCargoWeight",
        "Вес груза не может быть меньше нуля");
    
    public static Error IncorrectNumberPattern() => Error.Problem(
        "Order.IncorrectNumberPattern",
        "Неверный формат номера");
    
    public static Error NotFound(int id) => Error.NotFound(
        "Order.NotFound",
        $"Заказ с id = {id} не существует");
}