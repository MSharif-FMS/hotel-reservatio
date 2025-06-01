csharp
using MediatR;
using HotelBookingSystem.Application.Features.Rooms.Queries;
using HotelBookingSystem.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HotelBookingSystem.Application.DTOs; // Assuming RoomDto is in this namespace
using System.Linq;

namespace HotelBookingSystem.Application.Features.Rooms.Handlers
{
    public class GetAllRoomsQueryHandler : IRequestHandler<GetAllRoomsQuery, IEnumerable<RoomDto>>
    {
        private readonly IRoomRepository _roomRepository;

        public GetAllRoomsQueryHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<RoomDto>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
        {
            var rooms = await _roomRepository.GetAllAsync();

            // Map entities to DTOs (assuming a simple mapping for now)
            var roomDtos = rooms.Select(room => new RoomDto
            {
                Id = room.Id,
                HotelId = room.HotelId,
                RoomTypeId = room.RoomTypeId,
                RoomNumber = room.RoomNumber,
                FloorNumber = room.FloorNumber,
                ViewType = room.ViewType,
                IsSmoking = room.IsSmoking,
                IsAccessible = room.IsAccessible,
                IsActive = room.IsActive
            }).ToList();

            return roomDtos;
        }
    }
}