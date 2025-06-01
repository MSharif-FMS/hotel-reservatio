csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.RoomTypes.Commands
{
    public class DeleteRoomTypeCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }