csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.RoomServices.Queries;

public class GetRoomServiceByIdQuery : IRequest<RoomServiceDto>
{
    public long Id { get; set; }
}