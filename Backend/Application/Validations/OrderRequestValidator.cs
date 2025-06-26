using Application.Requests;
using FluentValidation;

namespace Application.Validations;

public class OrderRequestValidator : AbstractValidator<CreateOrderRequest>
{
    public OrderRequestValidator()
    {
        RuleFor(cor => cor.CitySender).NotEmpty();
        RuleFor(cor => cor.AddressSender).NotEmpty();
        RuleFor(cor => cor.CityReceiver).NotEmpty();
        RuleFor(cor => cor.AddressReceiver).NotEmpty();
        RuleFor(cor => cor.CargoWeightInKg).GreaterThan(0);
    }
}