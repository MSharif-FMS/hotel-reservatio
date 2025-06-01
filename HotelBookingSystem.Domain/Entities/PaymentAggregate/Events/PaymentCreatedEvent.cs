csharp
using HotelBookingSystem.Domain.Common;
using MediatR;
using System;

namespace HotelBookingSystem.Domain.Entities.PaymentAggregate.Events
{
    public class PaymentCreatedEvent : BaseDomainEvent
    {
        public long PaymentId { get; }
        public long ReservationId { get; }
        public decimal Amount { get; }
        public string Currency { get; }

        public PaymentCreatedEvent(long paymentId, long reservationId, decimal amount, string currency)
        {
            PaymentId = paymentId;
            ReservationId = reservationId;
            Amount = amount;
            Currency = currency;
        }
    }
}