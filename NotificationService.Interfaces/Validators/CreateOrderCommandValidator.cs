using FluentValidation;

namespace NotificationService.Application
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(t => t.BuyerEmail)
                .EmailAddress()
                .Length(1,100);

            RuleFor(t => t.BuyerName)
                .Length(1, 100);

            RuleFor(t => t.Adress)
                .Length(1, 100);

            RuleFor(t => t.City)
                .Length(1, 100);

            RuleFor(t => t.ProductId)
                .NotEmpty();
        }
    }
}
