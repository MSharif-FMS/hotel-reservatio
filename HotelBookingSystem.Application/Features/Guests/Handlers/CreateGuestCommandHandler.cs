csharp
using MediatR;
using HotelBookingSystem.Application.Features.Guests.Commands;
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Guests.Handlers
{    
    public class CreateGuestCommandHandler : IRequestHandler<CreateGuestCommand, long>
    {
        private readonly IGuestRepository _guestRepository;

        public CreateGuestCommandHandler(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<long> Handle(CreateGuestCommand request, CancellationToken cancellationToken)
        {
            var guest = new Guest
            {
                ReservationRoomId = request.ReservationRoomId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                IdType = request.IdType,
                IdNumber = request.IdNumber,
                Nationality = request.Nationality,
                IsPrimary = request.IsPrimary,
                CreatedAt = System.DateTimeOffset.UtcNow
            };

            await _guestRepository.AddAsync(guest);

            return guest.Id;
        }
    }
}