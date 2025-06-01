csharp
using MediatR;
using HotelBookingSystem.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using HotelBookingSystem.Application.Features.Rooms.Commands;

namespace HotelBookingSystem.Application.Features.Rooms.Handlers
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, bool>
    {
        private readonly IRoomRepository _repository;

        public DeleteRoomCommandHandler(IRoomRepository roomRepository)
        {
            _repository = roomRepository;
        }

        public async Task<bool> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAsync(request.Id);
        }
    }
}