csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.RatePlans.Commands
{
    public class UpdateRatePlanCommand : IRequest<bool>
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
    }
}