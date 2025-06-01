csharp
using MediatR;
using HotelBookingSystem.Application.Features.RoomTypes.DTOs;

namespace HotelBookingSystem.Application.Features.RoomTypes.Queries
{
    public class GetRoomTypesByHotelIdQuery : IRequest<IEnumerable<RoomTypeDto>>
    {
        public long HotelId { get; set; } = 0;
    }
}