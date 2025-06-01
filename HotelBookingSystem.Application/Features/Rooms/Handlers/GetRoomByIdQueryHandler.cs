csharp
using MediatR;
using HotelBookingSystem.Application.Features.Rooms.Queries;
using HotelBookingSystem.Domain.Interfaces;

// Assuming RoomDto is defined elsewhere in the Application layer
namespace HotelBookingSystem.Application.Features.Rooms.Handlers
{
    public class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, RoomDto>
    {
        private readonly IRoomRepository _roomRepository;

        public GetRoomByIdQueryHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<RoomDto> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetByIdAsync(request.Id);

            if (room == null)
            {
                return null; // Or throw a custom not found exception
            }

            // Map the Room entity to RoomDto
            var roomDto = new RoomDto
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
            };

            return roomDto;
        }
    }
}