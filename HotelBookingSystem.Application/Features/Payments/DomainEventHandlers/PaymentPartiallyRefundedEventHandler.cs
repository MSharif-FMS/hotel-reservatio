csharp
using MediatR;
using Microsoft.Extensions.Logging;
using HotelBookingSystem.Domain.Entities.PaymentAggregate.Events;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Payments.DomainEventHandlers
{
    public class PaymentPartiallyRefundedEventHandler : INotificationHandler<PaymentPartiallyRefundedEvent>
    {
        private readonly ILogger<PaymentPartiallyRefundedEventHandler> _logger;
        // Inject necessary services here (e.g., notification service, accounting service)

        public PaymentPartiallyRefundedEventHandler(ILogger<PaymentPartiallyRefundedEventHandler> logger /*, other services */)
        {
            _logger = logger;
            // Initialize injected services
        }

        public Task Handle(PaymentPartiallyRefundedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Payment Partially Refunded Event Handled: Payment ID {notification.PaymentId}, Amount {notification.PartiallyRefundedAmount}");

            // TODO: Implement logic to react to a partial payment refund
            // Examples:
            // - Update accounting records
            // - Send a notification to the user about the partial refund
            // - Update the status of the payment or related entities if necessary

            return Task.CompletedTask;
        }
    }
}