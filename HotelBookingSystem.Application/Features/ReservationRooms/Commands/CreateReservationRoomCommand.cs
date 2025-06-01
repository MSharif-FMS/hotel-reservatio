csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.ReservationRooms.Commands
{
    public class CreateReservationRoomCommand : IRequest<long>
    {
        public long ReservationId { get; set; }
        public long RoomId { get; set; }
        public long RatePlanId { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public decimal PricePerNight { get; set; }
        public string? SpecialRequests { get; set; }
    }
}