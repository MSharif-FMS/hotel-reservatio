csharp
using MediatR;
using HotelBookingSystem.Domain.Entities.RoomAggregate.Events;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace HotelBookingSystem.Application.Features.Rooms.DomainEventHandlers
{
    public class RoomStatusChangedEventHandler : INotificationHandler<RoomStatusChangedEvent>
    {
        private readonly ILogger<RoomStatusChangedEventHandler> _logger;
        // Inject other necessary services here

        public RoomStatusChangedEventHandler(ILogger<RoomStatusChangedEventHandler> logger/*, other services*/)
        {
            _logger = logger;
            // Initialize other services
        }

        public Task Handle(RoomStatusChangedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Room Status Changed Event Received: RoomId = {notification.RoomId}, OldStatus = {notification.OldStatus}, NewStatus = {notification.NewStatus}, OccurredOn = {notification.OccurredOn}");

            // Implement logic to react to the room status change
            // For example:
            // - Update a read model for room availability
            // - Send a notification to housekeeping
            // - Trigger a billing process if the status change affects billing

            return Task.CompletedTask;
        }
    }
}