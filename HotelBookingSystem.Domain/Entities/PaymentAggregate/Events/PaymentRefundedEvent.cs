csharp
using HotelBookingSystem.Domain.Common;
using System;

namespace HotelBookingSystem.Domain.Entities.PaymentAggregate.Events
{
    public class PaymentRefundedEvent : BaseDomainEvent
    {
        public long PaymentId { get; }
        public decimal RefundAmount { get; }

        public PaymentRefundedEvent(long paymentId, decimal refundAmount)
        {
            PaymentId = paymentId;
            RefundAmount = refundAmount;
        }
    }
}