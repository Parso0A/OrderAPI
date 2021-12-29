using FluentValidation;

namespace Order.Service.Contract.Validations
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.Items)
                .NotEmpty()
                .NotNull()
                .WithMessage("Cannot Submit an Order without Products");
        }
    }
}
