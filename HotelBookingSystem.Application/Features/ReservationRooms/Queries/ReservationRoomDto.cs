csharp
namespace HotelBookingSystem.Application.Features.ReservationRooms.Queries
{
    public class ReservationRoomDto
    {
        public long Id { get; set; }
        public long ReservationId { get; set; }
        public long RoomId { get; set; }
        public long RatePlanId { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public decimal PricePerNight { get; set; }
        public string Status { get; set; }
        public string? SpecialRequests { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}