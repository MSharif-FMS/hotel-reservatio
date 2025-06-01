csharp
namespace HotelBookingSystem.Application.Features.Facilities.Queries
{
    public class FacilityDto
    {
        public long Id { get; set; }
        public long HotelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool IsChargeable { get; set; }
        // OperatingHours can be represented as a string or a custom object
        public string OperatingHours { get; set; } 
        public bool IsActive { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}