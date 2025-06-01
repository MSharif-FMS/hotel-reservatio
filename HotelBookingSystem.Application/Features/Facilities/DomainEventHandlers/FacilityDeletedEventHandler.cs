csharp
using MediatR;
using Microsoft.Extensions.Logging;
using HotelBookingSystem.Domain.Entities.FacilityAggregate.Events;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Facilities.DomainEventHandlers
{
    public class FacilityDeletedEventHandler : INotificationHandler<FacilityDeletedEvent>
    {
        private readonly ILogger<FacilityDeletedEventHandler> _logger;
        // Inject other necessary services here

        public FacilityDeletedEventHandler(ILogger<FacilityDeletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(FacilityDeletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Facility Deleted: {notification.FacilityId} from Hotel: {notification.HotelId} at {notification.OccurredOn}");

            // TODO: Implement the logic to react to the FacilityDeletedEvent
            // This could involve:
            // - Cleaning up related data (e.g., images associated with the facility)
            // - Sending notifications
            // - Updating read models

            return Task.CompletedTask;
        }
    }
}