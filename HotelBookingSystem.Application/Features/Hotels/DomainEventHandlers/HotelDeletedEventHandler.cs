csharp
using MediatR;
using HotelBookingSystem.Domain.Entities.HotelAggregate.Events;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Hotels.DomainEventHandlers
{
    public class HotelDeletedEventHandler : INotificationHandler<HotelDeletedEvent>
    {        
        public HotelDeletedEventHandler()
        {
        }
        
        public Task Handle(HotelDeletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Hotel Deleted Event: Hotel with ID {notification.HotelId} was deleted.");

            // TODO: Implement logic to react to a hotel being deleted
            // This could involve:
            // - Archiving related data
            // - Sending notifications
            // - Invalidating cache

            return Task.CompletedTask;
        }
    }
}