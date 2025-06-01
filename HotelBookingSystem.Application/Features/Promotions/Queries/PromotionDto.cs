csharp
namespace HotelBookingSystem.Application.Features.Promotions.Queries
{
    public class PromotionDto
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DiscountType { get; set; }
        public decimal DiscountValue { get; set; }
        public DateTimeOffset ValidFrom { get; set; }
        public DateTimeOffset ValidTo { get; set; }
        public int? MinStay { get; set; }
        public decimal? MinAmount { get; set; }
        public long[]? ApplicableRoomTypes { get; set; }
        public DateTime[]? BlackoutDates { get; set; }
        public int? UsageLimit { get; set; }
        public int TimesUsed { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}