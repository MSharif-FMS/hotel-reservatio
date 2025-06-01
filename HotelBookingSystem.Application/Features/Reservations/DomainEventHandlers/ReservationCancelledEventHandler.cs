csharp
using MediatR;
using HotelBookingSystem.Domain.Entities.ReservationAggregate.Events;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Reservations.DomainEventHandlers
{
    public class ReservationCancelledEventHandler : INotificationHandler<ReservationCancelledEvent>
    {
        // Assuming you have services like RoomAllocationService and RefundService
        // private readonly IRoomAllocationService _roomAllocationService;
        // private readonly IRefundService _refundService;
        // private readonly ILogger<ReservationCancelledEventHandler> _logger;

        public ReservationCancelledEventHandler(
            /* IRoomAllocationService roomAllocationService, IRefundService refundService, ILogger<ReservationCancelledEventHandler> logger */)
        {
            // _roomAllocationService = roomAllocationService;
            // _refundService = refundService;
            // _logger = logger;
        }

        public Task Handle(ReservationCancelledEvent notification, CancellationToken cancellationToken)
        {
            // Log the event
            // _logger.LogInformation($"Reservation Cancelled: {notification.ReservationId} with reason: {notification.CancellationReason}");

            // Logic to release room holds
            // await _roomAllocationService.ReleaseRoomsAsync(notification.ReservationId);

            // Logic to initiate refunds if necessary
            // await _refundService.InitiateRefundAsync(notification.ReservationId, notification.CancellationReason);

            // Add any other necessary actions

            return Task.CompletedTask;
        }
    }
}