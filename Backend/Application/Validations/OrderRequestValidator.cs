using Application.Requests;
using FluentValidation;

namespace Application.Validations;

public class OrderRequestValidator : AbstractValidator<CreateOrderRequest>
{
    public OrderRequestValidator()
    {
        RuleFor(cor => cor.CitySender).NotEmpty().MaximumLength(30);
        RuleFor(cor => cor.AddressSender).NotEmpty().MaximumLength(50);
        RuleFor(cor => cor.CityReceiver).NotEmpty().MaximumLength(30);
        RuleFor(cor => cor.AddressReceiver).NotEmpty().MaximumLength(50);
        RuleFor(cor => cor.CargoWeightInKg).GreaterThan(0).LessThan(10000);
    }
}