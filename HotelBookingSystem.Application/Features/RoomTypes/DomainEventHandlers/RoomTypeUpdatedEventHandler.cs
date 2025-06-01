using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using HotelBookingSystem.Domain.Entities.RoomTypeAggregate.Events;

namespace HotelBookingSystem.Application.Features.RoomTypes.DomainEventHandlers
{
    public class RoomTypeUpdatedEventHandler : INotificationHandler<RoomTypeUpdatedEvent>
    {
        private readonly ILogger<RoomTypeUpdatedEventHandler> _logger;
        // Inject necessary services here (e.g., IReadModelUpdater)

        public RoomTypeUpdatedEventHandler(ILogger<RoomTypeUpdatedEventHandler> logger /*, Injected Services */)
        {
            _logger = logger;
        }

        public async Task Handle(RoomTypeUpdatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Hotel Room Type Updated: {RoomTypeId} for Hotel {HotelId}", notification.RoomTypeId, notification.HotelId);

            // Implement logic to handle the event, e.g.:
            // - Update read models
            // - Trigger integrations with external systems
            // - Send notifications

            await Task.CompletedTask; // Replace with actual asynchronous operations
        }
    }
}