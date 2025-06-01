csharp
using MediatR;
using HotelBookingSystem.Application.Features.Rooms.Commands;
using HotelBookingSystem.Domain.Interfaces;

namespace HotelBookingSystem.Application.Features.Rooms.Handlers
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, bool>
    {
        private readonly IRoomRepository _roomRepository;

        public UpdateRoomCommandHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<bool> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetByIdAsync(request.Id);

            if (room == null)
            {
                return false; // Or throw a custom not found exception
            }

            // Update room properties
            room.HotelId = request.HotelId;
            room.RoomTypeId = request.RoomTypeId;
            room.RoomNumber = request.RoomNumber;
            room.FloorNumber = request.FloorNumber;
            room.ViewType = request.ViewType;
            room.IsSmoking = request.IsSmoking;
            room.IsAccessible = request.IsAccessible;
            room.IsActive = request.IsActive; // Assuming IsActive is part of update
            room.UpdatedAt = DateTimeOffset.UtcNow; // Update the updated_at timestamp

            return await _roomRepository.UpdateAsync(room);
        }
    }
}