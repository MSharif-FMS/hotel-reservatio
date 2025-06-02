csharp
namespace HotelBookingSystem.Application.Features.Services.Queries
{
    public class ServiceDto
    {
        public long Id { get; set; }
        public long HotelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public bool IsActive { get; set; }
    }
}