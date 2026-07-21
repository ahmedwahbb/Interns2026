using FluentValidation;
using NorthWaveConsole.Application.DTOs;

namespace NorthWaveConsole.Application.Validators
{
    public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("Customer name is required.")
                .MaximumLength(200).WithMessage("Customer name must not exceed 200 characters.");

            RuleFor(x => x.CustomerType)
                .IsInEnum().WithMessage("Customer type is invalid.");

            RuleFor(x => x.Items)
                .NotEmpty().WithMessage("Order must contain at least one item.");

            RuleForEach(x => x.Items)
                .SetValidator(new CreateOrderItemRequestValidator());
        }
    }
}
