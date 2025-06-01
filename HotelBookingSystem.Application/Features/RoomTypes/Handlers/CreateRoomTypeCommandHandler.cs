csharp
using MediatR;
using HotelBookingSystem.Application.Features.RoomTypes.Commands;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;


namespace HotelBookingSystem.Application.Features.RoomTypes.Handlers
{
    public class CreateRoomTypeCommandHandler : IRequestHandler<CreateRoomTypeCommand, long>
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public CreateRoomTypeCommandHandler(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        public async Task<long> Handle(CreateRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var roomType = new RoomType
            {
                HotelId = request.HotelId,
                Name = request.Name,
                Description = request.Description,
                BaseCapacity = request.BaseCapacity,
                MaxCapacity = request.MaxCapacity,
                BasePrice = request.BasePrice,
                SizeSqft = request.SizeSqft,
                BedConfiguration = request.BedConfiguration,
                Amenities = request.Amenities,
                IsActive = request.IsActive,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow
            };

            await _roomTypeRepository.AddAsync(roomType);

            return roomType.Id;
        }
    }
}