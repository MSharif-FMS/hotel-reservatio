csharp
using MediatR;
using Microsoft.Extensions.Logging;
using HotelBookingSystem.Domain.Entities.PromotionAggregate.Events;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Promotions.DomainEventHandlers
{
    public class PromotionActivatedEventHandler : INotificationHandler<PromotionActivatedEvent>
    {
        private readonly ILogger<PromotionActivatedEventHandler> _logger;

        public PromotionActivatedEventHandler(ILogger<PromotionActivatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(PromotionActivatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Promotion Activated: {notification.PromotionId}");

            // TODO: Implement logic to react to a promotion being activated,
            // e.g., update a read model, notify marketing, etc.

            return Task.CompletedTask;
        }
    }
}