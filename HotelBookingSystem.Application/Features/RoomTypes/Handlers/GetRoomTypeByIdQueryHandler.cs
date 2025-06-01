csharp
using HotelBookingSystem.Application.Features.RoomTypes.Queries;
using HotelBookingSystem.Domain.Interfaces;
using HotelBookingSystem.Application.DTOs.RoomTypes;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.RoomTypes.Handlers
{
    public class GetRoomTypeByIdQueryHandler : IRequestHandler<GetRoomTypeByIdQuery, RoomTypeDto>
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public GetRoomTypeByIdQueryHandler(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        public async Task<RoomTypeDto> Handle(GetRoomTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var roomType = await _roomTypeRepository.GetByIdAsync(request.Id);

            if (roomType == null)
            {
                return null; // Or throw a custom not found exception
            }

            // Map the RoomType entity to RoomTypeDto
            var roomTypeDto = new RoomTypeDto
            {
                Id = roomType.Id,
                HotelId = roomType.HotelId,
                Name = roomType.Name,
                Description = roomType.Description,
                BaseCapacity = roomType.BaseCapacity,
                MaxCapacity = roomType.MaxCapacity,
                BasePrice = roomType.BasePrice,
                Amenities = roomType.Amenities,
                SizeSqft = roomType.SizeSqft // Assuming SizeSqft exists in RoomTypeDto
            };

            return roomTypeDto;
        }
    }
}