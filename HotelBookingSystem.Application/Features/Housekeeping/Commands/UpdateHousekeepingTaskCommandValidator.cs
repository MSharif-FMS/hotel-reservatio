csharp
using FluentValidation;
using System;

namespace HotelBookingSystem.Application.Features.Housekeeping.Commands
{
    public class UpdateHousekeepingTaskCommandValidator : AbstractValidator<UpdateHousekeepingTaskCommand>
    {
        public UpdateHousekeepingTaskCommandValidator()
        {
            RuleFor(command => command.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(command => command.RoomId)
                .GreaterThan(0).WithMessage("RoomId must be greater than 0.");

            RuleFor(command => command.StaffId)
                .GreaterThan(0).WithMessage("StaffId must be greater than 0.");

            RuleFor(command => command.TaskType).NotEmpty().WithMessage("TaskType is required.");

            // Assuming Status is a string, adjust validation as needed (e.g., In("Pending", "Completed"))
            RuleFor(command => command.Status) 
                .NotEmpty().WithMessage("Status is required."); // Consider using a custom validator or enum for status

            RuleFor(command => command.ScheduledTime)
                .NotEmpty().WithMessage("ScheduledTime is required.");

            // RuleFor(command => command.CompletedTime)
            //     .GreaterThanOrEqualTo(command.ScheduledTime).When(command => command.CompletedTime.HasValue)
            //     .WithMessage("CompletedTime must be on or after ScheduledTime.");
        }
    }
}