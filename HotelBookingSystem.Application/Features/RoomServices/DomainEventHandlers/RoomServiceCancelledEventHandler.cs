csharp
using MediatR;
using HotelBookingSystem.Domain.Entities.RoomServiceAggregate.Events;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging; // Example service to inject

namespace HotelBookingSystem.Application.Features.RoomServices.DomainEventHandlers
{
    public class RoomServiceCancelledEventHandler : INotificationHandler<RoomServiceCancelledEvent>
    {
        private readonly ILogger<RoomServiceCancelledEventHandler> _logger;
        // Inject other necessary services here (e.g., notification service)

        public RoomServiceCancelledEventHandler(ILogger<RoomServiceCancelledEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(RoomServiceCancelledEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Room Service with ID {notification.RoomServiceId} was cancelled.");

            // Implement the logic to react to a cancelled room service event
            // e.g., Send a notification to the guest or staff

            return Task.CompletedTask;
        }
    }
}