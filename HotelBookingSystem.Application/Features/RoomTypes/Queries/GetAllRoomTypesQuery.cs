csharp
using MediatR;
using System.Collections.Generic;

namespace HotelBookingSystem.Application.Features.RoomTypes.Queries
{
    // Assuming RoomTypeDto exists and represents the data structure for a RoomType
    public class GetAllRoomTypesQuery : IRequest<IEnumerable<RoomTypeDto>>
    {
    }
}