csharp
using HotelBookingSystem.Application.Features.RoomServices.Commands;
using HotelBookingSystem.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.RoomServices.Handlers
{
    public class DeleteRoomServiceCommandHandler : IRequestHandler<DeleteRoomServiceCommand, Unit>
    {
        private readonly IRoomServiceRepository _roomServiceRepository;

        public DeleteRoomServiceCommandHandler(IRoomServiceRepository roomServiceRepository)
        {
            _roomServiceRepository = roomServiceRepository;
        }

        public async Task<Unit> Handle(DeleteRoomServiceCommand request, CancellationToken cancellationToken)
        {
            var roomService = await _roomServiceRepository.GetByIdAsync(request.RoomServiceId);

            if (roomService == null)
            {
                // Handle not found scenario, e.g., throw a custom exception
                throw new KeyNotFoundException($"Room Service with ID {request.RoomServiceId} not found.");
            }

            await _roomServiceRepository.DeleteAsync(roomService);

            return Unit.Value;
        }
    }
}