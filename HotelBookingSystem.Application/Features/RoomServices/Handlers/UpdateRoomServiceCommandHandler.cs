csharp
using HotelBookingSystem.Application.Features.RoomServices.Commands;
using HotelBookingSystem.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.RoomServices.Handlers
{
    public class UpdateRoomServiceCommandHandler : IRequestHandler<UpdateRoomServiceCommand, Unit>
    {
        private readonly IRoomServiceRepository _roomServiceRepository;

        public UpdateRoomServiceCommandHandler(IRoomServiceRepository roomServiceRepository)
        {
            _roomServiceRepository = roomServiceRepository;
        }

        public async Task<Unit> Handle(UpdateRoomServiceCommand request, CancellationToken cancellationToken)
        {
            var roomService = await _roomServiceRepository.GetByIdAsync(request.Id);

            if (roomService == null)
            {
                // Handle not found scenario, e.g., throw an exception
                throw new Exception($"Room Service with ID {request.Id} not found.");
            }

            // Update properties (assuming UpdateRoomServiceCommand has all necessary properties)
            roomService.Quantity = request.Quantity;
            roomService.RequestedTime = request.RequestedTime;
            roomService.Status = request.Status;
            roomService.Notes = request.Notes;
            roomService.UpdatedAt = DateTimeOffset.UtcNow;

            await _roomServiceRepository.UpdateAsync(roomService);

            return Unit.Value;
        }
    }
}