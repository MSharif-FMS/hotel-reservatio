csharp
using MediatR;
using HotelBookingSystem.Domain.Entities.RoomAggregate.Events;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Rooms.DomainEventHandlers
{
    public class RoomUpdatedEventHandler : INotificationHandler<RoomUpdatedEvent>
    {
        private readonly ILogger<RoomUpdatedEventHandler> _logger;
        // Inject other necessary services here

        public RoomUpdatedEventHandler(ILogger<RoomUpdatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(RoomUpdatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Room Updated: RoomId = {notification.RoomId}, RoomNumber = {notification.RoomNumber}");

            // Implement logic to react to the RoomUpdatedEvent
            // e.g., update a read model, send notifications, etc.

            return Task.CompletedTask;
        }
    }
}