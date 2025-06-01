csharp
namespace HotelBookingSystem.Application.Features.Payments.Queries
{
    public class PaymentDto
    {
        public long Id { get; set; }
        public long ReservationId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentGateway { get; set; }
        public string TransactionId { get; set; }
        public string Status { get; set; }
        public string CardLast4 { get; set; }
        public string CardBrand { get; set; }
        public string ReceiptUrl { get; set; }
        public DateTimeOffset? CapturedAt { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}