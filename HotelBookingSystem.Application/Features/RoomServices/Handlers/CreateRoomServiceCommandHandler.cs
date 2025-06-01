csharp
using MediatR;
using HotelBookingSystem.Application.Features.RoomServices.Commands;
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.RoomServices.Handlers
{
    public class CreateRoomServiceCommandHandler : IRequestHandler<CreateRoomServiceCommand, long>
    {
        private readonly IRoomServiceRepository _roomServiceRepository;

        public CreateRoomServiceCommandHandler(IRoomServiceRepository roomServiceRepository)
        {
            _roomServiceRepository = roomServiceRepository;
        }

        public async Task<long> Handle(CreateRoomServiceCommand request, CancellationToken cancellationToken)
        {
            var roomService = new Domain.Entities.RoomService
            {
                ReservationRoomId = request.ReservationRoomId,
                ServiceId = request.ServiceId,
                Quantity = request.Quantity,
                RequestedTime = request.RequestedTime,
                Status = request.Status, // Consider defaulting this in the entity or command
                Notes = request.Notes,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow
            };

            await _roomServiceRepository.AddAsync(roomService);

            return roomService.Id;
        }
    }
}