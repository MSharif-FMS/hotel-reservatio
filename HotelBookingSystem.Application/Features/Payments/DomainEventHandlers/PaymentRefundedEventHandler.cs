csharp
using MediatR;
using HotelBookingSystem.Domain.Entities.PaymentAggregate.Events;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace HotelBookingSystem.Application.Features.Payments.DomainEventHandlers
{
    public class PaymentRefundedEventHandler : INotificationHandler<PaymentRefundedEvent>
    {
        private readonly ILogger<PaymentRefundedEventHandler> _logger;
        // Inject other necessary services here

        public PaymentRefundedEventHandler(ILogger<PaymentRefundedEventHandler> logger /*, other services */)
        {
            _logger = logger;
            // Initialize other services
        }

        public Task Handle(PaymentRefundedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Payment refunded event received for PaymentId: {notification.PaymentId}. Refund Amount: {notification.RefundAmount}");

            // Implement logic to react to a payment being fully refunded, e.g.:
            // - Update accounting or reporting systems
            // - Send a refund confirmation email to the user

            return Task.CompletedTask;
        }
    }
}