csharp
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using HotelBookingSystem.Domain.Entities.RoomStatusAggregate.Events;

namespace HotelBookingSystem.Application.Features.RoomStatus.DomainEventHandlers
{
    public class RoomStatusUpdatedEventHandler : INotificationHandler<RoomStatusUpdatedEvent>
    {
        private readonly ILogger<RoomStatusUpdatedEventHandler> _logger;
        // Inject necessary services here (e.g., notification service, audit service)

        public RoomStatusUpdatedEventHandler(ILogger<RoomStatusUpdatedEventHandler> logger)
        {
            _logger = logger;
            // Initialize injected services
        }

        public Task Handle(RoomStatusUpdatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Room Status Updated: RoomId = {notification.RoomId}, Old Status = {notification.OldStatus}, New Status = {notification.NewStatus}");

            // Implement logic to react to the room status update
            // This could include:
            // - Notifying housekeeping staff
            // - Updating availability in another system
            // - Creating an audit log entry

            // Example: Log the event details
            _logger.LogInformation($"Processing RoomStatusUpdatedEvent for RoomId: {notification.RoomId}");

            return Task.CompletedTask;
        }
    }
}