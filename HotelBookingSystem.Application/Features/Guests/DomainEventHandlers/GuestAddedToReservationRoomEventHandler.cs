csharp
using MediatR;
using Microsoft.Extensions.Logging;
using HotelBookingSystem.Domain.Entities.GuestAggregate.Events;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Guests.DomainEventHandlers
{
    public class GuestAddedToReservationRoomEventHandler : INotificationHandler<GuestAddedToReservationRoomEvent>
    {
        private readonly ILogger<GuestAddedToReservationRoomEventHandler> _logger;
        // Inject necessary services here, e.g.:
        // private readonly IGuestRepository _guestRepository;

        public GuestAddedToReservationRoomEventHandler(ILogger<GuestAddedToReservationRoomEventHandler> logger/*, IGuestRepository guestRepository*/)
        {
            _logger = logger;
            //_guestRepository = guestRepository;
        }

        public Task Handle(GuestAddedToReservationRoomEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Guest with Id {notification.GuestId} added to ReservationRoom with Id {notification.ReservationRoomId}.");

            // Implement logic to react to the event, e.g.:
            // - Update a read model
            // - Send a notification
            // - Perform additional validation

            return Task.CompletedTask;
        }
    }
}