csharp
using MediatR;
using HotelBookingSystem.Domain.Entities.RoomAggregate.Events;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging; // Assuming you'll use logging

namespace HotelBookingSystem.Application.Features.Rooms.DomainEventHandlers
{
    public class RoomCreatedEventHandler : INotificationHandler<RoomCreatedEvent>
    {
        private readonly ILogger<RoomCreatedEventHandler> _logger;
        // Inject other necessary services here, e.g., notification service

        public RoomCreatedEventHandler(ILogger<RoomCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(RoomCreatedEvent notification, CancellationToken cancellationToken)
        {
            // Handle the RoomCreatedEvent
            // Example: Log the event, send a notification, update a read model

            _logger.LogInformation($"Room Created Event: Room ID {notification.RoomId}, Hotel ID {notification.HotelId}, Room Type ID {notification.RoomTypeId}, Room Number {notification.RoomNumber} occurred at {notification.OccurredOn}");

            // Perform other actions as needed
            // For example:
            // _notificationService.SendRoomCreatedNotification(notification.RoomId, notification.HotelId);

            return Task.CompletedTask;
        }
    }
}