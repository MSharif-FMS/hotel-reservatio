csharp
using FluentValidation;

namespace HotelBookingSystem.Application.Features.Housekeeping.Queries
{
    public class GetHousekeepingTasksByStaffIdQueryValidator : AbstractValidator<GetHousekeepingTasksByStaffIdQuery>
    {
        public GetHousekeepingTasksByStaffIdQueryValidator()
        {
            RuleFor(query => query.StaffId)
                .GreaterThan(0).WithMessage("Staff ID must be greater than 0.");
        }
    }
}