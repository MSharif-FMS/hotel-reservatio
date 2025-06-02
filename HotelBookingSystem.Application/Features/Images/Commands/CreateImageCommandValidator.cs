csharp
using FluentValidation;

namespace HotelBookingSystem.Application.Features.Images.Commands
{
    public class CreateImageCommandValidator : AbstractValidator<CreateImageCommand>
    {
        public CreateImageCommandValidator()
        {
            RuleFor(x => x.EntityType)
                .NotEmpty().WithMessage("Entity type is required.")
                .IsInEnum().WithMessage("Invalid entity type."); // Assuming EntityType is an enum

            RuleFor(x => x.EntityId)
                .GreaterThan(0).WithMessage("Entity ID must be greater than 0.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Image URL is required.")
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).When(x => !string.IsNullOrEmpty(x.ImageUrl))
                .WithMessage("Image URL must be a valid absolute URL.");
        }
    }
}