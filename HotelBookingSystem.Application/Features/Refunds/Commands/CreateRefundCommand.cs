csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Refunds.Commands
{
    public class CreateRefundCommand : IRequest<long>
    {
        public long PaymentId { get; set; }
        public decimal Amount { get; set; }
        public string? Reason { get; set; }
        public long? ProcessedBy { get; set; }
    }
}