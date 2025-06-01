csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Rooms.Queries
{
    public class GetRoomByIdQuery 
    {
        public long Id { get; set; }
    }
}