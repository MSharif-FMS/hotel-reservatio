csharp
using MediatR;
using Microsoft.Extensions.Logging;
using HotelBookingSystem.Domain.Entities.GuestAggregate.Events;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Guests.DomainEventHandlers
{
    public class GuestUpdatedEventHandler : INotificationHandler<GuestUpdatedEvent>
    {
        private readonly ILogger<GuestUpdatedEventHandler> _logger;
        // Inject other necessary services here

        public GuestUpdatedEventHandler(ILogger<GuestUpdatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(GuestUpdatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Guest Updated: GuestId = {notification.GuestId}");

            // Implement logic to react to the GuestUpdatedEvent
            // e.g., Update a read model, send a notification

            return Task.CompletedTask;
        }
    }
}