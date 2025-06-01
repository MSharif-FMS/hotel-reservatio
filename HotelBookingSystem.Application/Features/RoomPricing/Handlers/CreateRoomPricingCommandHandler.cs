csharp
using MediatR;
using HotelBookingSystem.Application.Features.RoomPricing.Commands;
using HotelBookingSystem.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.RoomPricing.Handlers
{
    public class CreateRoomPricingCommandHandler : IRequestHandler<CreateRoomPricingCommand, long>
    {
        private readonly IRoomPricingRepository _roomPricingRepository;

        public CreateRoomPricingCommandHandler(IRoomPricingRepository roomPricingRepository)
        {
            _roomPricingRepository = roomPricingRepository;
        }

        public async Task<long> Handle(CreateRoomPricingCommand request, CancellationToken cancellationToken)
        {
            var roomPricing = new Domain.Entities.RoomPricing
            {
                RoomTypeId = request.RoomTypeId,
                RatePlanId = request.RatePlanId,
                Date = request.Date,
                Price = request.Price,
                AvailableRooms = request.AvailableRooms,
                MinStay = request.MinStay,
                StopSell = request.StopSell,
                CreatedAt = System.DateTimeOffset.UtcNow,
                UpdatedAt = System.DateTimeOffset.UtcNow
            };

            await _roomPricingRepository.AddAsync(roomPricing);

            return roomPricing.Id;
        }
    }
}