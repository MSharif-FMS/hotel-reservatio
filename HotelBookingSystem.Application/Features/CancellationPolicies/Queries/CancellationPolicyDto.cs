csharp
namespace HotelBookingSystem.Application.Features.CancellationPolicies.Queries
{
    public class CancellationPolicyDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int HoursBeforeCheckin { get; set; }
        public int PenaltyPercent { get; set; }
    }
}