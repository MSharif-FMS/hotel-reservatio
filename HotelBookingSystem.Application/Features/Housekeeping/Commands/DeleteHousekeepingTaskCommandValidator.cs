csharp
using FluentValidation;

namespace HotelBookingSystem.Application.Features.Housekeeping.Commands.DeleteHousekeepingTask
{
    public class DeleteHousekeepingTaskCommandValidator : AbstractValidator<DeleteHousekeepingTaskCommand>
    {
        public DeleteHousekeepingTaskCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}