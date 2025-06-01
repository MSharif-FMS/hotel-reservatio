csharp
using MediatR;
using Microsoft.Extensions.Logging;
using HotelBookingSystem.Domain.Entities.RoomServiceAggregate.Events;

namespace HotelBookingSystem.Application.Features.RoomServices.DomainEventHandlers
{
    public class RoomServiceCompletedEventHandler : INotificationHandler<RoomServiceCompletedEvent>
    {
        private readonly ILogger<RoomServiceCompletedEventHandler> _logger;
        // Inject necessary services here (e.g., notification service, billing service)

        public RoomServiceCompletedEventHandler(ILogger<RoomServiceCompletedEventHandler> logger /*, other services */)
        {
            _logger = logger;
            // Initialize injected services
        }

        public Task Handle(RoomServiceCompletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Room Service Completed Event Handled: RoomServiceId {RoomServiceId}, Completed Time: {CompletedTime}",
                notification.RoomServiceId, notification.CompletedTime);

            // Implement logic to react to the RoomServiceCompletedEvent
            // e.g., update billing records, send notification to guest/staff

            return Task.CompletedTask;
        }
    }
}