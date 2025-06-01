csharp
using System;

namespace HotelBookingSystem.Domain.Entities
{
    public class ReservationRoom
    {
        public long Id { get; set; }
        public long ReservationId { get; set; }
        public long RoomId { get; set; }
        public long RatePlanId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public decimal PricePerNight { get; set; }
        public string Status { get; set; } // e.g., 'reserved', 'checked-in', 'checked-out', 'cancelled', 'no-show'
        public string? SpecialRequests { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        // Navigation Properties
        public Reservation Reservation { get; set; }
        public Room Room { get; set; }
        public RatePlan RatePlan { get; set; }
    }
}