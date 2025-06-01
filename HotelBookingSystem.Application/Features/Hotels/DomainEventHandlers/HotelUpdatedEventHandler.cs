csharp
using HotelBookingSystem.Domain.Entities.HotelAggregate.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Hotels.DomainEventHandlers
{
    public class HotelUpdatedEventHandler : INotificationHandler<HotelUpdatedEvent>
    {
        private readonly ILogger<HotelUpdatedEventHandler> _logger;
        // Inject other necessary services here (e.g., IReadModelService)

        public HotelUpdatedEventHandler(ILogger<HotelUpdatedEventHandler> logger /*, Other services */)
        {
            _logger = logger;
            // Initialize other services
        }

        public Task Handle(HotelUpdatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Hotel Updated Event: Hotel ID {notification.HotelId}, Name: {notification.Name}, Location: {notification.Location}");

            // Implement logic to react to a hotel update
            // For example:
            // - Update a read model for listing hotels
            // - Send notifications to subscribed users
            // - Trigger integration with a third-party service

            return Task.CompletedTask;
        }
    }
}