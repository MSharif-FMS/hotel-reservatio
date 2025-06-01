csharp
using MediatR;
using HotelBookingSystem.Application.Features.Rooms.Commands;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Domain.Interfaces;
using System.Threading;
using System;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Rooms.Handlers
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, long>
    {
        private readonly IRoomRepository _roomRepository;

        public CreateRoomCommandHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<long> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = new Room
            {
                HotelId = request.HotelId,
                RoomTypeId = request.RoomTypeId,
                RoomNumber = request.RoomNumber,
                FloorNumber = request.FloorNumber,
                ViewType = request.ViewType,
                IsSmoking = request.IsSmoking,
                IsAccessible = request.IsAccessible,
                IsActive = true, // Assuming new rooms are active by default
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow
            };

            await _roomRepository.AddAsync(room);

            return room.Id;
        }
    }
}