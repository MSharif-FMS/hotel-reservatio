csharp
using AutoMapper;
using HotelBookingSystem.Application.Features.Services.Queries.GetServicesByHotelId;
using HotelBookingSystem.Application.Features.Services.Queries;
using HotelBookingSystem.Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Services.Handlers
{
    public class GetServicesByHotelIdQueryHandler : IRequestHandler<GetServicesByHotelIdQuery, IEnumerable<ServiceDto>>
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public GetServicesByHotelIdQueryHandler(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ServiceDto>> Handle(GetServicesByHotelIdQuery request, CancellationToken cancellationToken)
        {
            var services = await _serviceRepository.GetByHotelIdAsync(request.HotelId);
            return _mapper.Map<IEnumerable<ServiceDto>>(services);
        }
    }
}