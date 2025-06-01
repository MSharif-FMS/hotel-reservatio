csharp
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using HotelBookingSystem.Domain.Entities.PromotionAggregate.Events;

namespace HotelBookingSystem.Application.Features.Promotions.DomainEventHandlers
{
    public class PromotionCreatedEventHandler : INotificationHandler<PromotionCreatedEvent>
    {
        private readonly ILogger<PromotionCreatedEventHandler> _logger;
        // Inject necessary services here, e.g., notification service

        public PromotionCreatedEventHandler(ILogger<PromotionCreatedEventHandler> logger /*, INotificationService notificationService */)
        {
            _logger = logger;
            // Initialize injected services
        }

        public Task Handle(PromotionCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"PromotionCreatedEvent received for Promotion ID: {notification.PromotionId}, Code: {notification.Code}, Name: {notification.Name}");

            // Implement logic to react to the event, e.g.:
            // - Notify marketing team
            // - Update a read model for promotions
            // - Trigger integration with a marketing platform

            // Example: Sending a simple notification (requires a notification service)
            // _notificationService.SendNotificationAsync($"New promotion created: {notification.Name} ({notification.Code})", cancellationToken);

            return Task.CompletedTask;
        }
    }
}