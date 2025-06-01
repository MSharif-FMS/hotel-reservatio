using MediatR;
using Microsoft.Extensions.Logging;
using HotelBookingSystem.Domain.Entities.RoomTypeAggregate.Events;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.RoomTypes.DomainEventHandlers
{
    public class RoomTypeCreatedEventHandler : INotificationHandler<RoomTypeCreatedEvent>
    {
        private readonly ILogger<RoomTypeCreatedEventHandler> _logger;
        // Inject other necessary services here (e.g., email service, integration service)

        public RoomTypeCreatedEventHandler(ILogger<RoomTypeCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(RoomTypeCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Room Type Created: RoomTypeId = {notification.RoomTypeId}, HotelId = {notification.HotelId}, Name = {notification.Name}");

            // TODO: Implement specific actions for RoomTypeCreatedEvent
            // Examples:
            // - Send a notification to hotel staff
            // - Update a read model for room type availability
            // - Trigger integration with a third-party system

            return Task.CompletedTask;
        }
    }
}