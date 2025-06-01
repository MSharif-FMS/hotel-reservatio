csharp
using MediatR;
using HotelBookingSystem.Application.Features.RoomPricing.Commands;
using HotelBookingSystem.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.RoomPricing.Handlers
{
    public class DeleteRoomPricingCommandHandler : IRequestHandler<DeleteRoomPricingCommand, bool>
    {
        private readonly IRoomPricingRepository _roomPricingRepository;

        public DeleteRoomPricingCommandHandler(IRoomPricingRepository roomPricingRepository)
        {
            _roomPricingRepository = roomPricingRepository;
        }

        public async Task<bool> Handle(DeleteRoomPricingCommand request, CancellationToken cancellationToken)
        {
            return await _roomPricingRepository.DeleteAsync(request.Id);
        }
    }
}