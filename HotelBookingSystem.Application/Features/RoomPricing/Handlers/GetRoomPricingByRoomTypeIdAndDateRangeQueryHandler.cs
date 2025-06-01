csharp
using HotelBookingSystem.Application.Features.RoomPricing.Queries;
using HotelBookingSystem.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.RoomPricing.Handlers
{
    public class GetRoomPricingByRoomTypeIdAndDateRangeQueryHandler : IRequestHandler<GetRoomPricingByRoomTypeIdAndDateRangeQuery, IEnumerable<RoomPricingDto>>
    {
        private readonly IRoomPricingRepository _roomPricingRepository;

        public GetRoomPricingByRoomTypeIdAndDateRangeQueryHandler(IRoomPricingRepository roomPricingRepository)
        {
            _roomPricingRepository = roomPricingRepository;
        }

        public async Task<IEnumerable<RoomPricingDto>> Handle(GetRoomPricingByRoomTypeIdAndDateRangeQuery request, CancellationToken cancellationToken)
        {
            var roomPricingEntries = await _roomPricingRepository.GetByRoomTypeIdAndDateRangeAsync(request.RoomTypeId, request.StartDate, request.EndDate);

            // TODO: Map RoomPricing entities to RoomPricingDto
            var roomPricingDtos = new List<RoomPricingDto>();
            foreach (var entry in roomPricingEntries)
            {
                roomPricingDtos.Add(new RoomPricingDto
                {
                    // Map properties here
                    Id = entry.Id,
                    RoomTypeId = entry.RoomTypeId,
                    RatePlanId = entry.RatePlanId,
                    Date = entry.Date,
                    Price = entry.Price,
                    AvailableRooms = entry.AvailableRooms,
                    MinStay = entry.MinStay,
                    StopSell = entry.StopSell
                });
            }

            return roomPricingDtos;
        }
    }
}