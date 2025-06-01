using MediatR;

namespace HotelBookingSystem.Application.Features.RoomTypes.Commands
{
    public class DeleteRoomTypeCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
csharp
using HotelBookingSystem.Application.Features.RoomTypes.Commands;
using HotelBookingSystem.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.RoomTypes.Handlers
{
    public class DeleteRoomTypeCommandHandler : IRequestHandler<DeleteRoomTypeCommand, bool>
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public DeleteRoomTypeCommandHandler(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        public async Task<bool> Handle(DeleteRoomTypeCommand request, CancellationToken cancellationToken)
        {
            // You might want to add validation here to ensure the room type exists
            return await _roomTypeRepository.DeleteAsync(request.Id);
        }
    }
}