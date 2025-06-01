csharp
using System;
using System.Collections.Generic;

namespace HotelBookingSystem.Domain.Entities
{
    public class CancellationPolicy
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int HoursBeforeCheckin { get; set; }
        public int PenaltyPercent { get; set; }
        public bool IsActive { get; set; }

        // Navigation property
        public ICollection<RatePlan> RatePlans { get; set; }
    }
}