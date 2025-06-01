csharp
using MediatR;
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Application.Features.Facilities.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

namespace HotelBookingSystem.Application.Features.Facilities.Handlers
{
    public class GetAllFacilitiesQueryHandler : IRequestHandler<GetAllFacilitiesQuery, IEnumerable<FacilityDto>>
    {
        private readonly IFacilityRepository _facilityRepository;
        private readonly IMapper _mapper;

        public GetAllFacilitiesQueryHandler(IFacilityRepository facilityRepository, IMapper mapper)
        {
            _facilityRepository = facilityRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FacilityDto>> Handle(GetAllFacilitiesQuery request, CancellationToken cancellationToken)
        {
            var facilities = await _facilityRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<FacilityDto>>(facilities);
        }
    }
}