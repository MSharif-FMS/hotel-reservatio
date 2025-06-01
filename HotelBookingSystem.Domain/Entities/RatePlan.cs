csharp
using HotelBookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;

namespace HotelBookingSystem.Domain.Entities
{
    public class RatePlan
    {
        public long Id { get; set; }
        public long HotelId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public long? CancellationPolicyId { get; set; }
        public bool IsBreakfastIncluded { get; set; }
        public bool IsRefundable { get; set; }
        public int? MinStay { get; set; }
        public int? MaxStay { get; set; }
        public int? AdvanceBookingDays { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        // Navigation Properties
        public Hotel Hotel { get; set; }
        public CancellationPolicy? CancellationPolicy { get; set; }
        public ICollection<RoomPricing> RoomPricing { get; set; }
    }
}