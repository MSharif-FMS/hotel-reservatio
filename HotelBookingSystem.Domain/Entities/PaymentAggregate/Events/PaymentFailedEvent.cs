csharp
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.PaymentAggregate.Events
{
    public class PaymentFailedEvent : BaseDomainEvent
    {
        public long PaymentId { get; }
        public string FailureReason { get; }

        public PaymentFailedEvent(long paymentId, string failureReason)
        {
            PaymentId = paymentId;
            FailureReason = failureReason;
        }
    }
}