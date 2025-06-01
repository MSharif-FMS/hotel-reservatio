csharp
using HotelBookingSystem.Domain.Common;
using System;

namespace HotelBookingSystem.Domain.Entities.PaymentAggregate.Events
{
    public class PaymentPartiallyRefundedEvent : BaseDomainEvent
    {
        public long PaymentId { get; }
        public decimal PartiallyRefundedAmount { get; }

        public PaymentPartiallyRefundedEvent(long paymentId, decimal partiallyRefundedAmount)
        {
            PaymentId = paymentId;
            PartiallyRefundedAmount = partiallyRefundedAmount;
        }
    }
}