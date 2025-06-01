csharp
using System;
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.PaymentAggregate.Events
{
    public class PaymentCompletedEvent : BaseDomainEvent
    {
        public long PaymentId { get; }
        public string TransactionId { get; }
        public DateTimeOffset CapturedAt { get; }

        public PaymentCompletedEvent(long paymentId, string transactionId, DateTimeOffset capturedAt)
        {
            PaymentId = paymentId;
            TransactionId = transactionId;
            CapturedAt = capturedAt;
        }
    }
}