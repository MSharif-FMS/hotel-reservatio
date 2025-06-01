csharp
using MediatR;
using HotelBookingSystem.Application.Features.RoomTypes.Queries;
using HotelBookingSystem.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.RoomTypes.Handlers
{
    public class GetRoomTypesByHotelIdQueryHandler : IRequestHandler<GetRoomTypesByHotelIdQuery, IEnumerable<RoomTypeDto>>
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public GetRoomTypesByHotelIdQueryHandler(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        public async Task<IEnumerable<RoomTypeDto>> Handle(GetRoomTypesByHotelIdQuery request, CancellationToken cancellationToken)
        {
            var roomTypes = await _roomTypeRepository.GetByHotelIdAsync(request.HotelId);
            if (roomTypes == null) return null; // Handle case where no room types are found

            // Map RoomType entities to RoomTypeDto
            var roomTypeDtos = new List<RoomTypeDto>();
            foreach (var roomType in roomTypes)
            {
                roomTypeDtos.Add(new RoomTypeDto
                {
                    Id = roomType.Id,
                    HotelId = roomType.HotelId,
                    Name = roomType.Name,
                    Description = roomType.Description,
                    BaseCapacity = roomType.BaseCapacity,
                    MaxCapacity = roomType.MaxCapacity,
                    BasePrice = roomType.BasePrice,
                    Amenities = roomType.Amenities,
                    SizeSqft = roomType.SizeSqft,
                    BedConfiguration = roomType.BedConfiguration,
                    IsActive = roomType.IsActive,
                    CreatedAt = roomType.CreatedAt,
                    UpdatedAt = roomType.UpdatedAt
                });
            }

            return roomTypeDtos;
        }
    }
}