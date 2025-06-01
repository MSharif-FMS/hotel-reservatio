csharp
using MediatR;
using Microsoft.Extensions.Logging;
using HotelBookingSystem.Domain.Entities.HotelAggregate.Events;

namespace HotelBookingSystem.Application.Features.Hotels.DomainEventHandlers
{
    public class HotelCreatedEventHandler : INotificationHandler<HotelCreatedEvent>
    {
        private readonly ILogger<HotelCreatedEventHandler> _logger;

        public HotelCreatedEventHandler(ILogger<HotelCreatedEventHandler> logger /*, INotificationService notificationService */)
        {
            _logger = logger;
            // _notificationService = notificationService;
        }

        public Task Handle(HotelCreatedEvent notification, CancellationToken cancellationToken)
 {
            _logger.LogInformation($"Hotel Created Event: Hotel ID: {notification.HotelId}, Name: {notification.Name}, Location: {notification.Location}, Occurred On: {notification.OccurredOn}");

            return Task.CompletedTask;
        }
    }
}