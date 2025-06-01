csharp
using HotelBookingSystem.Application.Features.Guests.Queries;
using HotelBookingSystem.Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Guests.Handlers
{
    public class GetGuestsByReservationRoomIdQueryHandler : IRequestHandler<GetGuestsByReservationRoomIdQuery, IEnumerable<GuestDto>>
    {
        private readonly IGuestRepository _guestRepository;

        public GetGuestsByReservationRoomIdQueryHandler(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<IEnumerable<GuestDto>> Handle(GetGuestsByReservationRoomIdQuery request, CancellationToken cancellationToken)
        {
            var guests = await _guestRepository.GetGuestsByReservationRoomIdAsync(request.ReservationRoomId, cancellationToken);

            // Assuming you have a mapping configured (e.g., using AutoMapper)
            // For now, let's manually map
            var guestDtos = new List<GuestDto>();
            foreach (var guest in guests)
            {
                guestDtos.Add(new GuestDto
                {
                    Id = guest.Id,
                    ReservationRoomId = guest.ReservationRoomId,
                    FirstName = guest.FirstName,
                    LastName = guest.LastName,
                    Email = guest.Email,
                    Phone = guest.Phone,
                    IdType = guest.IdType,
                    IdNumber = guest.IdNumber,
                    Nationality = guest.Nationality,
                    IsPrimary = guest.IsPrimary,
                    CreatedAt = guest.CreatedAt
                });
            }

            return guestDtos;
        }
    }
}