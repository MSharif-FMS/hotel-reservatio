csharp
using MediatR;
using HotelBookingSystem.Application.Features.Rooms.Queries;
using HotelBookingSystem.Domain.Interfaces;
using System.Collections.Generic;

namespace HotelBookingSystem.Application.Features.Rooms.Handlers
{
    public class GetRoomsByRoomTypeIdQueryHandler : IRequestHandler<GetRoomsByRoomTypeIdQuery, IEnumerable<RoomDto>>
    {
        private readonly IRoomRepository _roomRepository;

        public GetRoomsByRoomTypeIdQueryHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<RoomDto>> Handle(GetRoomsByRoomTypeIdQuery request, CancellationToken cancellationToken)
        {
            var rooms = await _roomRepository.GetByRoomTypeIdAsync(request.RoomTypeId);

            // In a real application, you would use a mapper like AutoMapper
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