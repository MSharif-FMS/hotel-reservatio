csharp
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HotelBookingSystem.Domain.Entities.RefundAggregate.Events;
using Microsoft.Extensions.Logging;

namespace HotelBookingSystem.Application.Features.Refunds.DomainEventHandlers
{
    public class RefundFailedEventHandler : INotificationHandler<RefundFailedEvent>
    {
        private readonly ILogger<RefundFailedEventHandler> _logger;
        // Inject necessary services here

        public RefundFailedEventHandler(ILogger<RefundFailedEventHandler> logger)
        {
            _logger = logger;
            // Initialize injected services
        }

        public Task Handle(RefundFailedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogWarning($"Refund with Id {notification.RefundId} failed. Reason: {notification.Reason}");

            // Implement logic to react to a failed refund
            // This could involve notifying the user, updating related entities, etc.

            return Task.CompletedTask;
        }
    }
}