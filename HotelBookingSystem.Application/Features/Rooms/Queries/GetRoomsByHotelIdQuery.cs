csharp
using MediatR;
using System.Collections.Generic;
using HotelBookingSystem.Application.DTOs.Room;

namespace HotelBookingSystem.Application.Features.Rooms.Queries
{
    public class GetRoomsByHotelIdQuery : IRequest<IEnumerable<RoomDto>>
    {
        public long HotelId { get; set; }
    }
}