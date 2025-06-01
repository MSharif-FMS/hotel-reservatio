csharp
using AutoMapper;
using MediatR;
using HotelBookingSystem.Application.Features.Guests.Queries;
using HotelBookingSystem.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Guests.Handlers
{
    public class GetGuestByIdQueryHandler : IRequestHandler<GetGuestByIdQuery, GuestDto>
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IMapper _mapper;

        public GetGuestByIdQueryHandler(IGuestRepository guestRepository, IMapper mapper)
        {
            _guestRepository = guestRepository;
            _mapper = mapper;
        }

        public async Task<GuestDto> Handle(GetGuestByIdQuery request, CancellationToken cancellationToken)
        {
            var guest = await _guestRepository.GetByIdAsync(request.Id);

            if (guest == null)
            {
                // Handle not found scenario, perhaps throw a custom exception or return null
                return null; 
            }

            return _mapper.Map<GuestDto>(guest);
        }
    }
}