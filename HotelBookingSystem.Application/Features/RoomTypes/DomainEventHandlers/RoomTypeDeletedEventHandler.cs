csharp
using MediatR;
using Microsoft.Extensions.Logging;

using HotelBookingSystem.Domain.Entities.RoomTypeAggregate.Events;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.RoomTypes.DomainEventHandlers
{
    public class RoomTypeDeletedEventHandler : INotificationHandler<RoomTypeDeletedEvent>
    {
        private readonly ILogger<RoomTypeDeletedEventHandler> _logger;
        // Add any other necessary services here

        public RoomTypeDeletedEventHandler(ILogger<RoomTypeDeletedEventHandler> logger /*, Other Services */ )
        {
            _logger = logger;
            // Initialize other services
        }

        public Task Handle(RoomTypeDeletedEvent notification, CancellationToken cancellationToken)
        {
            // Implement the logic to handle the RoomTypeDeletedEvent
            // This could involve logging, cleaning up related data, sending notifications, etc.

            _logger.LogInformation($"Room Type Deleted Event Handled: Room Type ID {notification.RoomTypeId}, Hotel ID {notification.HotelId}");

            // Example: Clean up related room data (if not handled by database cascades)
            // _roomRepository.DeleteRoomsByRoomTypeId(notification.RoomTypeId);

            return Task.CompletedTask;
        }
    }
}