csharp
using System;

namespace HotelBookingSystem.Domain.Entities
{
    public class Review
    {
        public long Id { get; set; }
        public long HotelId { get; set; }
        public long? UserId { get; set; } // Nullable as per schema
        public long? ReservationId { get; set; } // Nullable as per schema
        public int Rating { get; set; }
        public int? Cleanliness { get; set; } // Nullable
        public int? Comfort { get; set; } // Nullable
        public int? Location { get; set; } // Nullable
        public int? Service { get; set; } // Nullable
        public string Comment { get; set; }
        public bool IsApproved { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        // Navigation Properties
        public Hotel Hotel { get; set; }
        public User User { get; set; }
        public Reservation Reservation { get; set; }
    }
}