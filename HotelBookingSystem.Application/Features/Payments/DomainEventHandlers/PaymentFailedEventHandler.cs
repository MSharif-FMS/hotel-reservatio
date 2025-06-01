csharp
using MediatR;
using HotelBookingSystem.Domain.Entities.PaymentAggregate.Events;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using HotelBookingSystem.Application.Interfaces; // Assuming you have interfaces for services

namespace HotelBookingSystem.Application.Features.Payments.DomainEventHandlers
{
    public class PaymentFailedEventHandler : INotificationHandler<PaymentFailedEvent>
    {
        private readonly ILogger<PaymentFailedEventHandler> _logger;
        // private readonly INotificationService _notificationService; // Example service
        // private readonly IReservationService _reservationService; // Example service

        public PaymentFailedEventHandler(ILogger<PaymentFailedEventHandler> logger
            /*, INotificationService notificationService, IReservationService reservationService*/)
        {
            _logger = logger;
            // _notificationService = notificationService;
            // _reservationService = reservationService;
        }

        public async Task Handle(PaymentFailedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogWarning($"PaymentFailedEvent received for Payment ID: {notification.PaymentId}. Reason: {notification.Reason}");

            // TODO: Implement actions to take when a payment fails
            // Example actions:
            // - Notify the user that the payment failed.
            // - Log the failure details for investigation.
            // - Potentially initiate a process to retry payment or cancel the reservation.

            // await _notificationService.SendPaymentFailureNotification(notification.PaymentId, notification.Reason);
            // await _reservationService.HandlePaymentFailure(notification.ReservationId);

            await Task.CompletedTask; // Replace with actual async operations
        }
    }
}