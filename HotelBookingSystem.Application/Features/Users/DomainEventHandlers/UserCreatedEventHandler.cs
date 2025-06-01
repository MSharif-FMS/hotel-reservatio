csharp
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using HotelBookingSystem.Domain.Entities.UserAggregate.Events;

namespace HotelBookingSystem.Application.Features.Users.DomainEventHandlers
{
    public class UserCreatedEventHandler : INotificationHandler<UserCreatedEvent>
    {
        private readonly ILogger<UserCreatedEventHandler> _logger;
        // private readonly IEmailService _emailService; // Example of injecting a service

        public UserCreatedEventHandler(ILogger<UserCreatedEventHandler> logger/*, IEmailService emailService*/)
        {
            _logger = logger;
            // _emailService = emailService;
        }

        public Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"UserCreatedEvent handled for user: {notification.UserId}");

            // Example: Send a welcome email (requires an IEmailService implementation)
            // await _emailService.SendWelcomeEmailAsync(notification.Email, notification.Username);

            return Task.CompletedTask;
        }
    }
}