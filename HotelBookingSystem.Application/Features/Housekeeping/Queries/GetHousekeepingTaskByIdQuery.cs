csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Housekeeping.Queries;

public class GetHousekeepingTaskByIdQuery : IRequest<HousekeepingDto>
{
    public long Id { get; set; }
}