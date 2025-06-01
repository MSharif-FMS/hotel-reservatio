csharp
using MediatR;
using System;

namespace HotelBookingSystem.Domain.Common
{
    public abstract class BaseDomainEvent : INotification
    {
        public DateTimeOffset OccurredOn { get; private set; }

        protected BaseDomainEvent()
        {
            OccurredOn = DateTimeOffset.UtcNow;
        }
    }
}