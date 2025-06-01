csharp
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using HotelBookingSystem.Domain.Entities.RoomServiceAggregate.Events;

namespace HotelBookingSystem.Application.Features.RoomServices.DomainEventHandlers
{
    public class RoomServiceRequestedEventHandler : INotificationHandler<RoomServiceRequestedEvent>
    {
        private readonly ILogger<RoomServiceRequestedEventHandler> _logger;
        // Inject necessary services here (e.g., notification service, logging service)

        public RoomServiceRequestedEventHandler(ILogger<RoomServiceRequestedEventHandler> logger)
        {
            _logger = logger;
            // Initialize injected services
        }

        public Task Handle(RoomServiceRequestedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Room Service Requested: RoomServiceId {notification.RoomServiceId}, ReservationRoomId {notification.ReservationRoomId}, ServiceId {notification.ServiceId}");

            // Implement logic to react to the room service requested event
            // This could involve:
            // - Notifying relevant staff (e.g., via a messaging service)
            // - Logging the event for audit purposes
            // - Updating a read model for display in a staff dashboard

            return Task.CompletedTask;
        }
    }
}