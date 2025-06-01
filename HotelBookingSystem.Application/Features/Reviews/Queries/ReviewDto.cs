csharp
using System;

namespace HotelBookingSystem.Application.Features.Reviews.Queries
{
    public class ReviewDto
    {
        public long Id { get; set; }
        public long HotelId { get; set; }
        public long? UserId { get; set; }
        public long? ReservationId { get; set; }
        public int Rating { get; set; }
        public int? Cleanliness { get; set; }
        public int? Comfort { get; set; }
        public int? Location { get; set; }
        public int? Service { get; set; }
        public string Comment { get; set; }
        public bool? IsApproved { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}