csharp
using MediatR;
using HotelBookingSystem.Application.Features.RoomTypes.Queries;
using HotelBookingSystem.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HotelBookingSystem.Application.DTOs;

namespace HotelBookingSystem.Application.Features.RoomTypes.Handlers
{
    public class GetAllRoomTypesQueryHandler : IRequestHandler<GetAllRoomTypesQuery, IEnumerable<RoomTypeDto>>
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public GetAllRoomTypesQueryHandler(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        public async Task<IEnumerable<RoomTypeDto>> Handle(GetAllRoomTypesQuery request, CancellationToken cancellationToken)
        {
            var roomTypes = await _roomTypeRepository.GetAllAsync();
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
                    Amenities = roomType.Amenities
                });
            }

            return roomTypeDtos;
        }
    }
}