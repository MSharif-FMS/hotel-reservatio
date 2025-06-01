csharp
namespace HotelBookingSystem.Application.Features.Hotels.Queries
{
    public class HotelDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; } // Assuming Address is a string for simplicity
        public decimal? Rating { get; set; }
        public int? StarRating { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
    }
}