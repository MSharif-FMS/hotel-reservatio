csharp
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HotelBookingSystem.Domain.Entities.GuestAggregate.Events;
using Microsoft.Extensions.Logging;

namespace HotelBookingSystem.Application.Features.Guests.DomainEventHandlers
{
    public class GuestRemovedFromReservationRoomEventHandler : INotificationHandler<GuestRemovedFromReservationRoomEvent>
    {
        private readonly ILogger<GuestRemovedFromReservationRoomEventHandler> _logger;
        // Inject necessary services here, e.g., notification service

        public GuestRemovedFromReservationRoomEventHandler(ILogger<GuestRemovedFromReservationRoomEventHandler> logger /*, Inotificationservice notificationService */)
        {
            _logger = logger;
            // _notificationService = notificationService;
        }

        public Task Handle(GuestRemovedFromReservationRoomEvent notification, CancellationToken cancellationToken)
        {
            // Handle the domain event: Guest removed from a reservation room
            _logger.LogInformation($"Guest {notification.GuestId} removed from Reservation Room {notification.ReservationRoomId} at {notification.OccurredOn}");

            // Example: Send a notification or perform other actions
            // _notificationService.SendGuestRemovalNotification(notification.GuestId, notification.ReservationRoomId);

            return Task.CompletedTask;
        }
    }
}