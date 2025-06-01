csharp
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HotelBookingSystem.Domain.Entities.PromotionAggregate.Events;
using Microsoft.Extensions.Logging; // Example service injection

namespace HotelBookingSystem.Application.Features.Promotions.DomainEventHandlers
{
    public class PromotionDeletedEventHandler : INotificationHandler<PromotionDeletedEvent>
    {
        private readonly ILogger<PromotionDeletedEventHandler> _logger;
        // Inject other necessary services here (e.g., repository for related data cleanup)

        public PromotionDeletedEventHandler(ILogger<PromotionDeletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(PromotionDeletedEvent notification, CancellationToken cancellationToken)
        {
            // Handle the domain event: PromotionDeletedEvent
            _logger.LogInformation($"Promotion Deleted: {notification.PromotionId}, Code: {notification.Code}");

            // TODO: Implement logic to react to a promotion being deleted.
            // This might include:
            // - Archiving related data
            // - Notifying users or systems
            // - Invalidating cached promotion data

            return Task.CompletedTask;
        }
    }
}