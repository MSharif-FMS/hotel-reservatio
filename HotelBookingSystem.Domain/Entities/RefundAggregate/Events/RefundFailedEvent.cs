csharp
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.RefundAggregate.Events
{
    public class RefundFailedEvent : BaseDomainEvent
    {
        public long RefundId { get; }
        public string ReasonForFailure { get; }

        public RefundFailedEvent(long refundId, string reasonForFailure)
        {
            RefundId = refundId;
            ReasonForFailure = reasonForFailure;
        }
    }
}