csharp
using AutoMapper;
using MediatR;
using HotelBookingSystem.Application.DTOs.Hotel;
using HotelBookingSystem.Application.Features.Hotels.Queries.GetHotelsByLocation;
using HotelBookingSystem.Application.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Hotels.Handlers
{
    public class GetHotelsByLocationQueryHandler : IRequestHandler<GetHotelsByLocationQuery, IEnumerable<HotelDto>>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public GetHotelsByLocationQueryHandler(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HotelDto>> Handle(GetHotelsByLocationQuery request, CancellationToken cancellationToken)
        {
            var hotels = await _hotelRepository.GetHotelsByLocationAsync(request.Location);
            return _mapper.Map<IEnumerable<HotelDto>>(hotels);
        }
    }
}