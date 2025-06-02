csharp
using FluentValidation;

namespace HotelBookingSystem.Application.Features.Payments.Commands
{
    public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
    {
        public CreatePaymentCommandValidator()
        {
            RuleFor(p => p.ReservationId)
                .NotEmpty().WithMessage("Reservation ID is required.")
                .GreaterThan(0).WithMessage("Reservation ID must be greater than 0.");

            RuleFor(p => p.Amount)
                .NotEmpty().WithMessage("Amount is required.")
                .GreaterThan(0).WithMessage("Amount must be greater than 0.");

            RuleFor(p => p.Currency)
                .NotEmpty().WithMessage("Currency is required.")
                .MaximumLength(3).WithMessage("Currency cannot exceed 3 characters."); // Assuming currency code like USD, EUR

            RuleFor(p => p.PaymentMethod)
                .NotEmpty().WithMessage("Payment method is required.")
                .IsIn(["credit_card", "debit_card", "bank_transfer", "cash", "other"])
                .WithMessage("Invalid payment method.");
        }
    }
}