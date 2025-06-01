csharp
using MediatR;
using System.Collections.Generic;

namespace HotelBookingSystem.Application.Features.Rooms.Queries
{
    public class GetAllRoomsQuery : IRequest<IEnumerable<RoomDto>> 
    {
        // No properties needed for this query
    }
}