csharp
using System;

namespace HotelBookingSystem.Domain.Entities
{
    public class RoomPricing
    {
        public long Id { get; set; }
        public long RoomTypeId { get; set; }
        public long RatePlanId { get; set; }
        public DateOnly Date { get; set; }
        public decimal Price { get; set; }
        public int AvailableRooms { get; set; }
        public int? MinStay { get; set; }
        public bool StopSell { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        // Navigation Properties
        public RoomType RoomType { get; set; }
        public RatePlan RatePlan { get; set; }
    }
}