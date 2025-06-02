csharp
using FluentValidation;

namespace HotelBookingSystem.Application.Features.Housekeeping.Commands
{
    public class CreateHousekeepingTaskCommandValidator : AbstractValidator<CreateHousekeepingTaskCommand>
    {
        public CreateHousekeepingTaskCommandValidator()
        {
            RuleFor(command => command.RoomId)
                .GreaterThan(0).WithMessage("RoomId must be a positive integer.");

            RuleFor(command => command.StaffId)
                .GreaterThan(0).WithMessage("StaffId must be a positive integer.");

            RuleFor(command => command.TaskType)
                .NotEmpty().WithMessage("TaskType is required.")
                .IsInEnum().WithMessage("Invalid TaskType value."); // Assuming TaskType is an enum

            RuleFor(command => command.ScheduledTime)
                .GreaterThan(DateTimeOffset.UtcNow).WithMessage("ScheduledTime must be in the future.");
        }
    }
}