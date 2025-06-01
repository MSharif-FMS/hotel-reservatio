csharp
using HotelBookingSystem.Application.Features.Guests.Commands;
using HotelBookingSystem.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Guests.Handlers
{
    public class DeleteGuestCommandHandler : IRequestHandler<DeleteGuestCommand, Unit>
    {
        private readonly IGuestRepository _guestRepository;

        public DeleteGuestCommandHandler(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<Unit> Handle(DeleteGuestCommand request, CancellationToken cancellationToken)
        {
            var guestToDelete = await _guestRepository.GetByIdAsync(request.Id, cancellationToken);

            if (guestToDelete == null)
            {
                // TODO: Implement custom exception for not found
                throw new Exception($"Guest with id {request.Id} not found."); // Use a more specific exception later
            }

            await _guestRepository.DeleteAsync(guestToDelete);

            return Unit.Value;
        }
    }
}