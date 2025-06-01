csharp
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HotelBookingSystem.Domain.Entities.PaymentAggregate.Events;
using Microsoft.Extensions.Logging;
using HotelBookingSystem.Application.Interfaces; // Assuming you have services defined here

namespace HotelBookingSystem.Application.Features.Payments.DomainEventHandlers
{
    public class PaymentCreatedEventHandler : INotificationHandler<PaymentCreatedEvent>
    {
        private readonly ILogger<PaymentCreatedEventHandler> _logger;
        //private readonly INotificationService _notificationService; // Example service
        //private readonly IReservationService _reservationService; // Example service

        public PaymentCreatedEventHandler(
            ILogger<PaymentCreatedEventHandler> logger
            /*, INotificationService notificationService, IReservationService reservationService*/)
        {
            _logger = logger;
            //_notificationService = notificationService;
            //_reservationService = reservationService;
        }

        public Task Handle(PaymentCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Payment Created Event Received: Payment ID {notification.PaymentId} for Reservation ID {notification.ReservationId}");

            // TODO: Implement actions to take when a payment is created
            // Examples:
            // - Send a payment confirmation notification to the user.
            // - Update the status of the associated reservation to 'processing' or similar.
            // - Log the event for auditing or analytics.

            // Example: Sending a notification (requires INotificationService)
            // _notificationService.SendPaymentConfirmation(notification.ReservationId, notification.Amount, notification.Currency);

            // Example: Updating reservation status (requires IReservationService)
            // _reservationService.UpdateReservationStatus(notification.ReservationId, "ProcessingPayment");

            return Task.CompletedTask;
        }
    }
}