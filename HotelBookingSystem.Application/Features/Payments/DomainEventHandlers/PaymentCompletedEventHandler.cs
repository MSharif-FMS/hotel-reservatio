csharp
using MediatR;
using Microsoft.Extensions.Logging;
using HotelBookingSystem.Domain.Entities.PaymentAggregate.Events;
using HotelBookingSystem.Application.Interfaces; // Assuming your services are here

namespace HotelBookingSystem.Application.Features.Payments.DomainEventHandlers
{
    public class PaymentCompletedEventHandler : INotificationHandler<PaymentCompletedEvent>
    {
        private readonly ILogger<PaymentCompletedEventHandler> _logger;
        private readonly IReservationService _reservationService; // Example service

        public PaymentCompletedEventHandler(ILogger<PaymentCompletedEventHandler> logger, IReservationService reservationService)
        {
            _logger = logger;
            _reservationService = reservationService;
        }

        public async Task Handle(PaymentCompletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Payment Completed Event Received: Payment ID - {notification.PaymentId}");

            // TODO: Implement logic to react to a completed payment
            // For example, update the reservation status to confirmed
            // try
            // {
            //     await _reservationService.ConfirmReservationByPaymentIdAsync(notification.PaymentId);
            // }
            // catch (Exception ex)
            // {
            //     _logger.LogError(ex, $"Error confirming reservation for payment ID {notification.PaymentId}");
            // }

            await Task.CompletedTask;
        }
    }
}