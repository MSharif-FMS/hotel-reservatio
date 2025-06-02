csharp
using FluentValidation;
using HotelBookingSystem.Application.Features.Hotels.Commands.DeleteHotel;

namespace HotelBookingSystem.Application.Features.Hotels.Commands
{
    public class DeleteHotelCommandValidator : AbstractValidator<DeleteHotelCommand>
    {
        public DeleteHotelCommandValidator()
        {
            RuleFor(command => command.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}