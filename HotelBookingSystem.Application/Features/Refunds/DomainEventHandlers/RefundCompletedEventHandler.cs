csharp
using MediatR;
using Microsoft.Extensions.Logging;
using HotelBookingSystem.Domain.Entities.RefundAggregate.Events;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Refunds.DomainEventHandlers
{
    public class RefundCompletedEventHandler : INotificationHandler<RefundCompletedEvent>
    {
        private readonly ILogger<RefundCompletedEventHandler> _logger;
        // Inject necessary services here

        public RefundCompletedEventHandler(ILogger<RefundCompletedEventHandler> logger)
        {
            _logger = logger;
            // Initialize injected services
        }

        public Task Handle(RefundCompletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"RefundCompletedEvent handled for Refund ID: {notification.RefundId}");

            // TODO: Implement logic to react to a completed refund
            // This could include:
            // - Notifying the user that the refund is complete
            // - Updating related reservation or payment statuses
            // - Logging the completion details

            return Task.CompletedTask;
        }
    }
}