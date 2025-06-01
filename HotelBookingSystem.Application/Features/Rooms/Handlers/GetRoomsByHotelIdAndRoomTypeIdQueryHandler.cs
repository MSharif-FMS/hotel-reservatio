csharp
using MediatR;
using HotelBookingSystem.Application.Features.Rooms.Queries;
using HotelBookingSystem.Application.DTOs;
using HotelBookingSystem.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper; // Assuming you will use AutoMapper for mapping

namespace HotelBookingSystem.Application.Features.Rooms.Handlers
{
    public class GetRoomsByHotelIdAndRoomTypeIdQueryHandler : IRequestHandler<GetRoomsByHotelIdAndRoomTypeIdQuery, IEnumerable<RoomDto>>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper; // Inject AutoMapper

        public GetRoomsByHotelIdAndRoomTypeIdQueryHandler(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomDto>> Handle(GetRoomsByHotelIdAndRoomTypeIdQuery request, CancellationToken cancellationToken)
        {
            var rooms = await _roomRepository.GetByHotelIdAndRoomTypeIdAsync(request.HotelId, request.RoomTypeId);
            return _mapper.Map<IEnumerable<RoomDto>>(rooms);
        }
    }
}