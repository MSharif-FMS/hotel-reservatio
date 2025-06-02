csharp
using FluentValidation;

namespace HotelBookingSystem.Application.Features.Images.Commands
{
    public class DeleteImageCommandValidator : AbstractValidator<DeleteImageCommand>
    {
        public DeleteImageCommandValidator()
        {
            RuleFor(command => command.Id)
                .GreaterThan(0).WithMessage("Id must be a positive number.");
        }
    }
}