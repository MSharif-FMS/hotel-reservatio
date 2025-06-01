csharp
using HotelBookingSystem.Application.Features.RoomPricing.Commands;
using HotelBookingSystem.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.RoomPricing.Handlers
{
    public class UpdateRoomPricingCommandHandler : IRequestHandler<UpdateRoomPricingCommand, bool>
    {
        private readonly IRoomPricingRepository _roomPricingRepository;

        public UpdateRoomPricingCommandHandler(IRoomPricingRepository roomPricingRepository)
        {
            _roomPricingRepository = roomPricingRepository;
        }

        public async Task<bool> Handle(UpdateRoomPricingCommand request, CancellationToken cancellationToken)
        {
            var roomPricing = await _roomPricingRepository.GetByIdAsync(request.Id);

            if (roomPricing == null)
            {
                return false;
            }

            // Update properties based on the command.
            // Add null checks or other validation as needed.
            roomPricing.Price = request.Price;
            roomPricing.AvailableRooms = request.AvailableRooms;
            roomPricing.MinStay = request.MinStay;
            roomPricing.StopSell = request.StopSell;
            roomPricing.UpdatedAt = DateTimeOffset.UtcNow; // Or use a domain event/service for this

            return await _roomPricingRepository.UpdateAsync(roomPricing);
        }
    }
}