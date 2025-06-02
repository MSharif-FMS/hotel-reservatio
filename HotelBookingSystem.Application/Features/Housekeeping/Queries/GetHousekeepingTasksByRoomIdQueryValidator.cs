csharp
using FluentValidation;

namespace HotelBookingSystem.Application.Features.Housekeeping.Queries
{
    public class GetHousekeepingTasksByRoomIdQueryValidator : AbstractValidator<GetHousekeepingTasksByRoomIdQuery>
    {
        public GetHousekeepingTasksByRoomIdQueryValidator()
        {
            RuleFor(query => query.RoomId)
                .GreaterThan(0).WithMessage("Room ID must be greater than 0.");
        }
    }
}