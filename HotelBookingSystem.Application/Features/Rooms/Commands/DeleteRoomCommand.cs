csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Rooms.Commands
{
    public class DeleteRoomCommand : IRequest<bool>
    {
        public long RoomId { get; set; }
    }
}