csharp
using MediatR;
using HotelBookingSystem.Application.Features.RoomPricing.Queries;
using HotelBookingSystem.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HotelBookingSystem.Application.DTOs; 

namespace HotelBookingSystem.Application.Features.RoomPricing.Handlers
{
    public class GetAllRoomPricingQueryHandler : IRequestHandler<GetAllRoomPricingQuery, IEnumerable<RoomPricingDto>>
    {
        private readonly IRoomPricingRepository _roomPricingRepository;

        public GetAllRoomPricingQueryHandler(IRoomPricingRepository roomPricingRepository)
        {
            _roomPricingRepository = roomPricingRepository;
        }

        public async Task<IEnumerable<RoomPricingDto>> Handle(GetAllRoomPricingQuery request, CancellationToken cancellationToken)
        {
            var roomPricingEntries = await _roomPricingRepository.GetAllAsync();

            // TODO: Implement mapping from RoomPricing entity to RoomPricingDto
            var roomPricingDtos = new List<RoomPricingDto>();
            foreach (var entry in roomPricingEntries)
            {
                // Example mapping (replace with actual mapping logic)
                roomPricingDtos.Add(new RoomPricingDto
                {
                    Id = entry.Id,
                    RoomTypeId = entry.RoomTypeId,
                    RatePlanId = entry.RatePlanId,
                    Date = entry.Date,
                    Price = entry.Price,
                    AvailableRooms = entry.AvailableRooms,
                    MinStay = entry.MinStay,
                    StopSell = entry.StopSell
                    // Map other properties
                });
            }

            return roomPricingDtos;
        }
    }
}