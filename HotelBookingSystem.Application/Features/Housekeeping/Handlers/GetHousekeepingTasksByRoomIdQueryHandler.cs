csharp
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HotelBookingSystem.Application.Features.Housekeeping.Queries;
using HotelBookingSystem.Application.Interfaces;
using AutoMapper;

namespace HotelBookingSystem.Application.Features.Housekeeping.Handlers
{
    public class GetHousekeepingTasksByRoomIdQueryHandler : IRequestHandler<GetHousekeepingTasksByRoomIdQuery, IEnumerable<HousekeepingDto>>
    {
        private readonly IHousekeepingRepository _housekeepingRepository;
        private readonly IMapper _mapper;

        public GetHousekeepingTasksByRoomIdQueryHandler(IHousekeepingRepository housekeepingRepository, IMapper mapper)
        {
            _housekeepingRepository = housekeepingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HousekeepingDto>> Handle(GetHousekeepingTasksByRoomIdQuery request, CancellationToken cancellationToken)
        {
            var housekeepingTasks = await _housekeepingRepository.GetHousekeepingTasksByRoomIdAsync(request.RoomId);
            return _mapper.Map<IEnumerable<HousekeepingDto>>(housekeepingTasks);
        }
    }
}