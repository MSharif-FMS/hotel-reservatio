csharp
using MediatR;
using HotelBookingSystem.Application.Features.RoomPricing.Queries;
using HotelBookingSystem.Domain.Interfaces;
using HotelBookingSystem.Application.DTOs.RoomPricing; // Assuming you have a RoomPricingDto

namespace HotelBookingSystem.Application.Features.RoomPricing.Handlers
{
    public class GetRoomPricingByRatePlanIdAndDateRangeQueryHandler : IRequestHandler<GetRoomPricingByRatePlanIdAndDateRangeQuery, IEnumerable<RoomPricingDto>>
    {
        private readonly IRoomPricingRepository _roomPricingRepository;

        public GetRoomPricingByRatePlanIdAndDateRangeQueryHandler(IRoomPricingRepository roomPricingRepository)
        {
            _roomPricingRepository = roomPricingRepository;
        }

        public async Task<IEnumerable<RoomPricingDto>> Handle(GetRoomPricingByRatePlanIdAndDateRangeQuery request, CancellationToken cancellationToken)
        {
            var roomPricingList = await _roomPricingRepository.GetByRatePlanIdAndDateRangeAsync(request.RatePlanId, request.StartDate, request.EndDate);

            // TODO: Implement mapping from RoomPricing entity to RoomPricingDto
            var roomPricingDtos = roomPricingList.Select(rp => new RoomPricingDto
            {
                Id = rp.Id,
                RoomTypeId = rp.RoomTypeId,
                RatePlanId = rp.RatePlanId,
                Date = rp.Date,
                Price = rp.Price,
                AvailableRooms = rp.AvailableRooms,
                MinStay = rp.MinStay,
                StopSell = rp.StopSell
                // Map other properties as needed
            }).ToList();

            return roomPricingDtos;
        }
    }
}