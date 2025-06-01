csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Payments.Commands
{
    public class CreatePaymentCommand : IRequest<long>
    {
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
    }
}