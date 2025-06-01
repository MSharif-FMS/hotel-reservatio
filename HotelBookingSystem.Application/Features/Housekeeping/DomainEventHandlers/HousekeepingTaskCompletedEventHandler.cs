csharp
using MediatR;
using Microsoft.Extensions.Logging;
using HotelBookingSystem.Domain.Entities.HousekeepingAggregate.Events;

namespace HotelBookingSystem.Application.Features.Housekeeping.DomainEventHandlers
{
    public class HousekeepingTaskCompletedEventHandler : INotificationHandler<HousekeepingTaskCompletedEvent>
    {
        private readonly ILogger<HousekeepingTaskCompletedEventHandler> _logger;
        // Inject other necessary services here, e.g., notification service

        public HousekeepingTaskCompletedEventHandler(ILogger<HousekeepingTaskCompletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(HousekeepingTaskCompletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Housekeeping Task Completed: Task ID {notification.HousekeepingId}, Completed at {notification.CompletedTime}");

            // TODO: Implement logic to react to the housekeeping task being completed.
            // This could include:
            // - Updating room status
            // - Notifying relevant staff
            // - Logging completion details

            return Task.CompletedTask;
        }
    }
}