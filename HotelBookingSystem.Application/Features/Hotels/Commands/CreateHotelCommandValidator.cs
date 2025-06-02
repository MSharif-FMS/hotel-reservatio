csharp
using FluentValidation;

namespace HotelBookingSystem.Application.Features.Hotels.Commands.CreateHotel
{
    public class CreateHotelCommandValidator : AbstractValidator<CreateHotelCommand>
    {
        public CreateHotelCommandValidator()
        {
            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("Hotel name is required.")
                .MaximumLength(250).WithMessage("Hotel name cannot exceed 250 characters.");

            RuleFor(command => command.Location)
                .NotEmpty().WithMessage("Hotel location is required.")
                .MaximumLength(250).WithMessage("Hotel location cannot exceed 250 characters.");

            RuleFor(command => command.Address)
                .NotEmpty().WithMessage("Hotel address is required.");
                // You might add more specific validation for the Address structure if it's a complex object

            RuleFor(command => command.ContactEmail)
                .NotEmpty().WithMessage("Contact email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MaximumLength(250).WithMessage("Contact email cannot exceed 250 characters.");

            RuleFor(command => command.ContactPhone)
                .NotEmpty().WithMessage("Contact phone is required.")
                .MaximumLength(50).WithMessage("Contact phone cannot exceed 50 characters.");
                // You might add a regex rule for phone number format validation
        }
    }
}