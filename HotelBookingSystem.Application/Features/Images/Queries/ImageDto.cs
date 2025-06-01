csharp
namespace HotelBookingSystem.Application.Features.Images.Queries
{
    public class ImageDto
    {
        public long Id { get; set; }
        public string EntityType { get; set; }
        public long EntityId { get; set; }
        public string ImageUrl { get; set; }
        public string? Caption { get; set; }
        public bool IsPrimary { get; set; }
        public int SortOrder { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}