csharp
using HotelBookingSystem.Application.Features.Hotels.Commands;
using HotelBookingSystem.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Hotels.Handlers
{
    public class DeleteHotelCommandHandler : IRequestHandler<DeleteHotelCommand, bool>
    {
        private readonly IHotelRepository _hotelRepository;

        public DeleteHotelCommandHandler(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public async Task<bool> Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
        {
            return await _hotelRepository.DeleteAsync(request.HotelId);
        }
    }
}