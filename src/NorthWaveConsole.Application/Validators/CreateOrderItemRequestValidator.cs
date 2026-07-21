using FluentValidation;
using NorthWaveConsole.Application.DTOs;

namespace NorthWaveConsole.Application.Validators
{
    public class CreateOrderItemRequestValidator : AbstractValidator<CreateOrderItemRequest>
    {
        public CreateOrderItemRequestValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(200);

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

            RuleFor(x => x.Qty)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.");
        }
    }
}
