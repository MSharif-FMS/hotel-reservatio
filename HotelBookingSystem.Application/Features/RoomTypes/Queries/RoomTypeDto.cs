csharp
namespace HotelBookingSystem.Application.Features.RoomTypes.Queries
{
    public class RoomTypeDto
    {
        public long Id { get; set; }
        public long HotelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BaseCapacity { get; set; }
        public int MaxCapacity { get; set; }
        public decimal BasePrice { get; set; }
        public string[] Amenities { get; set; }
    }
}