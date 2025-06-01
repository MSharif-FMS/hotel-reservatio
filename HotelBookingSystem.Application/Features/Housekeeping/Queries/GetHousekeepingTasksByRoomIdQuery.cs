csharp
using MediatR;
using System.Collections.Generic;

namespace HotelBookingSystem.Application.Features.Housekeeping.Queries
{
    public class GetHousekeepingTasksByRoomIdQuery : IRequest<IEnumerable<HousekeepingDto>>
    {
        public long RoomId { get; set; }
    }
}