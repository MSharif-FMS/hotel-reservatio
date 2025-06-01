csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.RatePlans.Commands
{
    public class CreateRatePlanCommand : IRequest<long>
    {
        public long HotelId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsBreakfastIncluded { get; set; }
        // Add other relevant properties from schema
        public int? CancellationPolicyId { get; set; } // Assuming cancellation_policy_id is int in schema
        public int? MinStay { get; set; }
        public int? MaxStay { get; set; }
        public int? AdvanceBookingDays { get; set; }
        public bool IsActive { get; set; } = true;
    }
}