csharp
using MediatR;
using HotelBookingSystem.Application.Features.Rooms.Queries;
using HotelBookingSystem.Domain.Interfaces;
using HotelBookingSystem.Application.Features.Rooms.Queries.Response;

namespace HotelBookingSystem.Application.Features.Rooms.Handlers
{
    public class GetRoomsByHotelIdQueryHandler : IRequestHandler<GetRoomsByHotelIdQuery, IEnumerable<RoomDto>>
    {
        private readonly IRoomRepository _roomRepository;

        public GetRoomsByHotelIdQueryHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<RoomDto>> Handle(GetRoomsByHotelIdQuery request, CancellationToken cancellationToken)
        {
            var rooms = await _roomRepository.GetByHotelIdAsync(request.HotelId);

            // In a real application, you would use a more robust mapping solution like AutoMapper.
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
            });

            return roomDtos;
        }
    }
}