csharp
using HotelBookingSystem.Domain.Common;
using System;

namespace HotelBookingSystem.Domain.Entities.RefundAggregate.Events
{
    public class RefundRequestedEvent : BaseDomainEvent
    {
        public long RefundId { get; }
        public long PaymentId { get; }
        public decimal Amount { get; }
        public string Reason { get; }

        public RefundRequestedEvent(long refundId, long paymentId, decimal amount, string reason)
        {
            RefundId = refundId;
            PaymentId = paymentId;
            Amount = amount;
            Reason = reason;
        }
    }
}