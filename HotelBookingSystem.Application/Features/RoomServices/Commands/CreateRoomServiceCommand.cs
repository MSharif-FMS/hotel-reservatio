csharp
using MediatR;
using System;

namespace HotelBookingSystem.Application.Features.RoomServices.Commands
{
    public class CreateRoomServiceCommand : IRequest<long>
    {
        public long ReservationRoomId { get; set; }
        public long ServiceId { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset RequestedTime { get; set; }
        public string? Notes { get; set; }
    }
}