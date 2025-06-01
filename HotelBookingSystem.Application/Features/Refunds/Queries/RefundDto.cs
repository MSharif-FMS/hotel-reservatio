csharp
namespace HotelBookingSystem.Application.Features.Refunds.Queries
{
    public class RefundDto
    {
        public long Id { get; set; }
        public long PaymentId { get; set; }
        public decimal Amount { get; set; }
        public string? Reason { get; set; }
        public long? ProcessedBy { get; set; }
        public string Status { get; set; } // e.g., "requested", "processing", "completed", "failed"
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}