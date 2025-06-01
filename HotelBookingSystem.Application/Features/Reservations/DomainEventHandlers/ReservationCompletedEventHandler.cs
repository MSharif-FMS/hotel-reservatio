csharp
using MediatR;
using HotelBookingSystem.Domain.Entities.ReservationAggregate.Events;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace HotelBookingSystem.Application.Features.Reservations.DomainEventHandlers
{
    public class ReservationCompletedEventHandler : INotificationHandler<ReservationCompletedEvent>
    {
        private readonly ILogger<ReservationCompletedEventHandler> _logger;
        // Inject necessary services here

        public ReservationCompletedEventHandler(ILogger<ReservationCompletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ReservationCompletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Reservation Completed: {notification.ReservationId} on {notification.OccurredOn}.");

            // Implement logic here to react to a completed reservation, e.g.:
            // - Update related systems
            // - Trigger guest review request email
            // - Update statistics

            return Task.CompletedTask;
        }
    }
}