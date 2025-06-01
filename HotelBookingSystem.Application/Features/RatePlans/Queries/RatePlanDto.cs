csharp
namespace HotelBookingSystem.Application.Features.RatePlans.Queries
{
    public class RatePlanDto
    {
        public long Id { get; set; }
        public long HotelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsBreakfastIncluded { get; set; }
        public bool IsRefundable { get; set; }
        public int? MinStay { get; set; }
        public int? MaxStay { get; set; }
    }
}