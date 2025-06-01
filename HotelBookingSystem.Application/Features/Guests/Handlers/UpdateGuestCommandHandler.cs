csharp
using HotelBookingSystem.Application.Features.Guests.Commands;
using HotelBookingSystem.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace HotelBookingSystem.Application.Features.Guests.Handlers
{
    public class UpdateGuestCommandHandler : IRequestHandler<UpdateGuestCommand, Unit>
    {
        private readonly IGuestRepository _guestRepository;

        public UpdateGuestCommandHandler(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<Unit> Handle(UpdateGuestCommand request, CancellationToken cancellationToken)
        {
            var guest = await _guestRepository.GetByIdAsync(request.Id);

            if (guest == null)
            {
                // Handle not found case, possibly throw a custom exception
                return Unit.Value;
            }

            // Update guest properties (mapping from command to entity)
            guest.FirstName = request.FirstName;
            guest.LastName = request.LastName;
            guest.Email = request.Email;
            guest.Phone = request.Phone;
            guest.IdType = request.IdType;
            guest.IdNumber = request.IdNumber;
            guest.Nationality = request.Nationality;
            guest.IsPrimary = request.IsPrimary;

            await _guestRepository.UpdateAsync(guest);

            return Unit.Value;
        }
    }
}