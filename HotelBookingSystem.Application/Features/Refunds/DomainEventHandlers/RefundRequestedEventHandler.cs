csharp
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using HotelBookingSystem.Domain.Entities.RefundAggregate.Events;

namespace HotelBookingSystem.Application.Features.Refunds.DomainEventHandlers
{
    public class RefundRequestedEventHandler : INotificationHandler<RefundRequestedEvent>
    {
        private readonly ILogger<RefundRequestedEventHandler> _logger;
        // private readonly IPaymentGatewayService _paymentGatewayService; // Example service
        // private readonly INotificationService _notificationService; // Example service

        public RefundRequestedEventHandler(ILogger<RefundRequestedEventHandler> logger
            /*, IPaymentGatewayService paymentGatewayService, INotificationService notificationService*/)
        {
            _logger = logger;
            // _paymentGatewayService = paymentGatewayService;
            // _notificationService = notificationService;
        }

        public async Task Handle(RefundRequestedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Refund Requested Event Handled: Refund ID {notification.RefundId}, Payment ID {notification.PaymentId}, Amount {notification.Amount}");

            // Example: Log the event, initiate refund in payment gateway, send notification
            // await _paymentGatewayService.InitiateRefundAsync(notification.PaymentId, notification.Amount, cancellationToken);
            // await _notificationService.SendRefundRequestNotificationAsync(notification.RefundId, notification.Amount, cancellationToken);

            await Task.CompletedTask; // Replace with actual async operations
        }
    }
}