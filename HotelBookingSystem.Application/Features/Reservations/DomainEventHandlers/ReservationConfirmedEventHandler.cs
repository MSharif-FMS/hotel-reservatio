csharp
using MediatR;
using Microsoft.Extensions.Logging;
using HotelBookingSystem.Domain.Entities.ReservationAggregate.Events;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Reservations.DomainEventHandlers
{
    public class ReservationConfirmedEventHandler : INotificationHandler<ReservationConfirmedEvent>
    {
        private readonly ILogger<ReservationConfirmedEventHandler> _logger;
        // Inject necessary services here, e.g., IEmailService, IBookingIntegrationService

        public ReservationConfirmedEventHandler(ILogger<ReservationConfirmedEventHandler> logger /*, IEmailService emailService, IBookingIntegrationService bookingIntegrationService */)
        {
            _logger = logger;
            // _emailService = emailService;
            // _bookingIntegrationService = bookingIntegrationService;
        }

        public Task Handle(ReservationConfirmedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Reservation Confirmed: {notification.ReservationId}");

            // TODO: Implement logic to react to a confirmed reservation
            // Examples:
            // - Send confirmation email to the user.
            // - Update external booking systems.
            // - Trigger room allocation process.

            return Task.CompletedTask;
        }
    }
}