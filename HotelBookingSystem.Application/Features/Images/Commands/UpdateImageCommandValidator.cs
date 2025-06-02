csharp
using FluentValidation;

namespace HotelBookingSystem.Application.Features.Images.Commands
{
    public class UpdateImageCommandValidator : AbstractValidator<UpdateImageCommand>
    {
        public UpdateImageCommandValidator()
        {
            RuleFor(command => command.Id)
                .GreaterThan(0).WithMessage("Image ID must be greater than 0.");

            RuleFor(command => command.Caption)
                .MaximumLength(500).WithMessage("Caption cannot exceed 500 characters.");

            // RuleFor(command => command.IsPrimary) // No specific validation needed unless you have business rules

            RuleFor(command => command.SortOrder)
                .GreaterThanOrEqualTo(0).WithMessage("Sort order must be non-negative.");
        }
    }
}