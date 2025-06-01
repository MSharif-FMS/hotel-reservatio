csharp
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HotelBookingSystem.Domain.Interfaces;
using HotelBookingSystem.Application.Features.RoomPricing.Queries;
using HotelBookingSystem.Application.DTOs;

namespace HotelBookingSystem.Application.Features.RoomPricing.Handlers
{
    public class GetRoomPricingByIdQueryHandler : IRequestHandler<GetRoomPricingByIdQuery, RoomPricingDto>
    {
        private readonly IRoomPricingRepository _roomPricingRepository;

        public GetRoomPricingByIdQueryHandler(IRoomPricingRepository roomPricingRepository)
        {
            _roomPricingRepository = roomPricingRepository;
        }

        public async Task<RoomPricingDto> Handle(GetRoomPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var roomPricing = await _roomPricingRepository.GetByIdAsync(request.Id);

            if (roomPricing == null)
            {
                return null; // Or throw a specific exception
            }

            // TODO: Map RoomPricing entity to RoomPricingDto
            var roomPricingDto = new RoomPricingDto
            {
                Id = roomPricing.Id,
                RoomTypeId = roomPricing.RoomTypeId,
                RatePlanId = roomPricing.RatePlanId,
                Date = roomPricing.Date,
                Price = roomPricing.Price,
                AvailableRooms = roomPricing.AvailableRooms,
                MinStay = roomPricing.MinStay,
                StopSell = roomPricing.StopSell,
                CreatedAt = roomPricing.CreatedAt,
                UpdatedAt = roomPricing.UpdatedAt
            };

            return roomPricingDto;
        }
    }
}