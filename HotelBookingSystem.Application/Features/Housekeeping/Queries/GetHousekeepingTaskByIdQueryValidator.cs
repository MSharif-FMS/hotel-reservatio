csharp
using FluentValidation; // Ensure this is correctly placed within the C# code block if applicable

namespace HotelBookingSystem.Application.Features.Housekeeping.Queries
{
    public class GetHousekeepingTaskByIdQueryValidator : AbstractValidator<GetHousekeepingTaskByIdQuery> // Updated class declaration if needed
    {
        public GetHousekeepingTaskByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}