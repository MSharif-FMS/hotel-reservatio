csharp
using FluentValidation;
using System.Linq;

namespace HotelBookingSystem.Application.Features.Housekeeping.Commands
{
    public class UpdateHousekeepingTaskStatusCommandValidator : AbstractValidator<UpdateHousekeepingTaskStatusCommand>
    {
        public UpdateHousekeepingTaskStatusCommandValidator()
        {
            RuleFor(command => command.Id)
                .GreaterThan(0).WithMessage("Housekeeping Task ID must be greater than 0.");

            RuleFor(command => command.Status)
                .NotEmpty().WithMessage("Status is required.")
                .Must(status => IsValidStatus(status)).WithMessage("Invalid status value.");
        }

        private bool IsValidStatus(string status)
        {
            // Define your allowed status values here
            var allowedStatuses = new[] { "assigned", "in-progress", "completed", "delayed" };
            return allowedStatuses.Contains(status.ToLower());
        }
    }
}