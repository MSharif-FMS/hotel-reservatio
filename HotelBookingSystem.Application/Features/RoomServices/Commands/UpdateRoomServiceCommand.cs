csharp
using MediatR;
using System;

namespace HotelBookingSystem.Application.Features.RoomServices.Commands
{
    public class UpdateRoomServiceCommand : IRequest<Unit>
    {
        public long Id { get; set; }
        public long ReservationRoomId { get; set; }
        public long ServiceId { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset RequestedTime { get; set; }
        public string Status { get; set; } // e.g., "requested", "in-progress", "completed", "cancelled"
        public string? Notes { get; set; }
    }
}