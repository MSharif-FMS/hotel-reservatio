csharp
using FluentValidation;

namespace HotelBookingSystem.Application.Features.Hotels.Commands.UpdateHotel
{
    public class UpdateHotelCommandValidator : AbstractValidator<UpdateHotelCommand>
    {
        public UpdateHotelCommandValidator()
        {
            RuleFor(command => command.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(250).WithMessage("Name must not exceed 250 characters.");

            RuleFor(command => command.Location)
                .NotEmpty().WithMessage("Location is required.")
                .MaximumLength(500).WithMessage("Location must not exceed 500 characters.");

            // Assuming Address is a string representation of JSONB for now
            RuleFor(command => command.Address)
                .NotEmpty().WithMessage("Address is required.");

            RuleFor(command => command.ContactEmail)
                .NotEmpty().WithMessage("Contact Email is required.")
                .EmailAddress().WithMessage("Invalid Contact Email format.");

            RuleFor(command => command.ContactPhone)
                .NotEmpty().WithMessage("Contact Phone is required.")
                .MaximumLength(50).WithMessage("Contact Phone must not exceed 50 characters.");

            RuleFor(command => command.Rating)
                .InclusiveBetween(0, 5).When(command => command.Rating.HasValue)
                .WithMessage("Rating must be between 0 and 5.");

            RuleFor(command => command.StarRating)
                .InclusiveBetween(1, 5).When(command => command.StarRating.HasValue)
                .WithMessage("Star Rating must be between 1 and 5.");
        }
    }
}