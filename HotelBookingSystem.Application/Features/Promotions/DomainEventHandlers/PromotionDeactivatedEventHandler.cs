csharp
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HotelBookingSystem.Domain.Entities.PromotionAggregate.Events;
using Microsoft.Extensions.Logging; // Example service

namespace HotelBookingSystem.Application.Features.Promotions.DomainEventHandlers
{
    public class PromotionDeactivatedEventHandler : INotificationHandler<PromotionDeactivatedEvent>
    {
        private readonly ILogger<PromotionDeactivatedEventHandler> _logger; // Example service

        public PromotionDeactivatedEventHandler(ILogger<PromotionDeactivatedEventHandler> logger) // Inject example service
        {
            _logger = logger;
        }

        public Task Handle(PromotionDeactivatedEvent notification, CancellationToken cancellationToken)
        {
            // Handle the domain event, e.g., log the deactivation
            _logger.LogInformation($"Promotion Deactivated: Promotion ID = {notification.PromotionId}");

            // Add any other logic here, e.g.,
            // - Notify users about the deactivation
            // - Update related systems or caches

            return Task.CompletedTask;
        }
    }
}