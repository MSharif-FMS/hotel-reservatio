csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.RoomTypes.Queries
{
    public class GetRoomTypeByIdQuery : IRequest<RoomTypeDto>
    {
        public long Id { get; set; }
    }
}