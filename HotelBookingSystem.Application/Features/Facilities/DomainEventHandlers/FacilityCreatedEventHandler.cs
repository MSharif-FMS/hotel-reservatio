csharp
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HotelBookingSystem.Domain.Entities.FacilityAggregate.Events;

namespace HotelBookingSystem.Application.Features.Facilities.DomainEventHandlers
{
    public class FacilityCreatedEventHandler : INotificationHandler<FacilityCreatedEvent>
    {
        // Inject necessary services here (e.g., logger, notification service)
        // private readonly ILogger<FacilityCreatedEventHandler> _logger;

        // public FacilityCreatedEventHandler(ILogger<FacilityCreatedEventHandler> logger)
        // {
        //     _logger = logger;
        // }

        public Task Handle(FacilityCreatedEvent notification, CancellationToken cancellationToken)
        {
            // TODO: Implement logic to handle the FacilityCreatedEvent
            // This could include logging, sending notifications, or updating read models

            // Example: Log the event
            // _logger.LogInformation($"Facility Created: {notification.FacilityId}, Name: {notification.Name}, Hotel: {notification.HotelId}");

            return Task.CompletedTask;
        }
    }
}