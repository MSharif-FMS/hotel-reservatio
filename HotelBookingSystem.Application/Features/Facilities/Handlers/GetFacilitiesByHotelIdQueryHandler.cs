csharp
using AutoMapper;
using HotelBookingSystem.Application.Features.Facilities.Queries;
using HotelBookingSystem.Application.Interfaces;
using MediatR;

namespace HotelBookingSystem.Application.Features.Facilities.Handlers
{
    public class GetFacilitiesByHotelIdQueryHandler : IRequestHandler<GetFacilitiesByHotelIdQuery, IEnumerable<FacilityDto>>
    {
        private readonly IFacilityRepository _facilityRepository;
        private readonly IMapper _mapper;

        public GetFacilitiesByHotelIdQueryHandler(IFacilityRepository facilityRepository, IMapper mapper)
        {
            _facilityRepository = facilityRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FacilityDto>> Handle(GetFacilitiesByHotelIdQuery request, CancellationToken cancellationToken)
        {
            var facilities = await _facilityRepository.GetFacilitiesByHotelIdAsync(request.HotelId);
            return _mapper.Map<IEnumerable<FacilityDto>>(facilities);
        }
    }
}