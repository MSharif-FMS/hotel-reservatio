csharp
using MediatR;
using HotelBookingSystem.Application.Features.ReservationRooms.Queries;

namespace HotelBookingSystem.Application.Features.ReservationRooms.Queries;

public class GetReservationRoomByIdQuery : IRequest<ReservationRoomDto>
{
    public long Id { get; set; }
}