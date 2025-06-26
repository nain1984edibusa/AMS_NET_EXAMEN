using FluentValidation;
using Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Commands.CalculatePrice;

namespace Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Validators
{
    public class CalculatePriceCommandValidator : AbstractValidator<CalculatePriceCommand>
    {
        public CalculatePriceCommandValidator()
        {
            RuleFor(m => m.ProductCode).NotEmpty();
            RuleFor(m => m.SelectedCovers).NotNull();
            RuleFor(m => m.Answers).NotNull();
        }
    }
}
