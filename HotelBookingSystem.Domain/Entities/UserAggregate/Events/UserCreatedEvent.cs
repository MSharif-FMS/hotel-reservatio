csharp
using HotelBookingSystem.Domain.Common;

namespace HotelBookingSystem.Domain.Entities.UserAggregate.Events
{
    public class UserCreatedEvent : BaseDomainEvent
    {
        public long UserId { get; }
        public string Username { get; }
        public string Email { get; }

        public UserCreatedEvent(long userId, string username, string email)
        {
            UserId = userId;
            Username = username;
            Email = email;
        }
    }
}