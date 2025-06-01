csharp
using MediatR;
using HotelBookingSystem.Domain.Entities.RoomAggregate.Events;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace HotelBookingSystem.Application.Features.Rooms.DomainEventHandlers
{
    public class RoomDeletedEventHandler : INotificationHandler<RoomDeletedEvent>
    {
        private readonly ILogger<RoomDeletedEventHandler> _logger;

        public RoomDeletedEventHandler(ILogger<RoomDeletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(RoomDeletedEvent notification, CancellationToken cancellationToken)
        {
            // TODO: Implement logic to react to a RoomDeletedEvent
            _logger.LogInformation($"RoomDeletedEvent received for RoomId: {notification.RoomId}");

            // Example: Clean up related data, send notifications, etc.
            // You would typically interact with other services or repositories here.

            return Task.CompletedTask;
        }
    }
}