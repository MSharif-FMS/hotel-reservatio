csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.RoomServices.Commands;

public class DeleteRoomServiceCommand : IRequest<Unit>
{
    public long Id { get; set; }
}