csharp
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using HotelBookingSystem.Domain.Entities.FacilityAggregate.Events;

namespace HotelBookingSystem.Application.Features.Facilities.DomainEventHandlers
{
    public class FacilityUpdatedEventHandler : INotificationHandler<FacilityUpdatedEvent>
    {
        private readonly ILogger<FacilityUpdatedEventHandler> _logger;

        public FacilityUpdatedEventHandler(ILogger<FacilityUpdatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(FacilityUpdatedEvent notification, CancellationToken cancellationToken)
        {
            // TODO: Implement logic to react to a FacilityUpdatedEvent
            _logger.LogInformation("FacilityUpdatedEvent handled for Facility ID: {FacilityId}, Name: {FacilityName}", notification.FacilityId, notification.Name);

            // Example: Update a read model, send a notification, etc.

            return Task.CompletedTask;
        }
    }
}