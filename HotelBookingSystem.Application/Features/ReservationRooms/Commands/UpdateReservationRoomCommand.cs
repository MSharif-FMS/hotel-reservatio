csharp
using MediatR;
using System;

namespace HotelBookingSystem.Application.Features.ReservationRooms.Commands
{
    public class UpdateReservationRoomCommand : IRequest<Unit>
    {
        public long Id { get; set; }
        public long ReservationId { get; set; }
        public long RoomId { get; set; }
        public long RatePlanId { get; set; }
        public DateTimeOffset CheckInDate { get; set; }
        public DateTimeOffset CheckOutDate { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public decimal PricePerNight { get; set; }
        public string Status { get; set; }
        public string? SpecialRequests { get; set; }
    }
}