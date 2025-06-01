csharp
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using HotelBookingSystem.Domain.Entities.ReservationAggregate.Events;
using Microsoft.Extensions.Logging;
// Assuming you have interfaces for email and payment services
// using HotelBookingSystem.Application.Interfaces.Services; 

namespace HotelBookingSystem.Application.Features.Reservations.DomainEventHandlers
{
    public class ReservationCreatedEventHandler : INotificationHandler<ReservationCreatedEvent>
    {
        private readonly ILogger<ReservationCreatedEventHandler> _logger;
        // private readonly IEmailService _emailService; // Example injected service
        // private readonly IPaymentService _paymentService; // Example injected service

        public ReservationCreatedEventHandler(
            ILogger<ReservationCreatedEventHandler> logger
            /*, IEmailService emailService, IPaymentService paymentService*/) // Inject services
        {
            _logger = logger;
            // _emailService = emailService;
            // _paymentService = paymentService;
        }

        public Task Handle(ReservationCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Reservation Created Event Received: ReservationId = {notification.ReservationId}, ReservationNumber = {notification.ReservationNumber}");

            // TODO: Implement actions based on the reservation creation event
            // Examples:
            // - Send a confirmation email to the user
            // - Initiate the payment process
            // - Update inventory/availability for the reserved rooms
            // - Log the event for auditing purposes

            // Example of sending an email (assuming IEmailService is injected)
            // _emailService.SendReservationConfirmationEmail(notification.UserId, notification.ReservationId);

            // Example of initiating payment (assuming IPaymentService is injected)
            // _paymentService.InitiatePayment(notification.ReservationId, notification.TotalAmount);

            return Task.CompletedTask;
        }
    }
}