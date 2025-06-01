csharp
using MediatR;
using HotelBookingSystem.Application.Features.RoomTypes.Commands;
using HotelBookingSystem.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace HotelBookingSystem.Application.Features.RoomTypes.Handlers
{
    public class UpdateRoomTypeCommandHandler : IRequestHandler<UpdateRoomTypeCommand, bool>
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public UpdateRoomTypeCommandHandler(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        public async Task<bool> Handle(UpdateRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var roomType = await _roomTypeRepository.GetByIdAsync(request.Id);

            if (roomType == null)
            {
                return false; // Room type not found
            }

            roomType.Name = request.Name;
            roomType.Description = request.Description;
            roomType.BaseCapacity = request.BaseCapacity;
            roomType.MaxCapacity = request.MaxCapacity;
            roomType.BasePrice = request.BasePrice;
            roomType.SizeSqft = request.SizeSqft;
            roomType.BedConfiguration = request.BedConfiguration;
            roomType.Amenities = request.Amenities;
            roomType.IsActive = request.IsActive;
            roomType.UpdatedAt = DateTimeOffset.UtcNow; // Update timestamp

            return await _roomTypeRepository.UpdateAsync(roomType);
        }
    }
}