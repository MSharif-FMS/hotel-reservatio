csharp
using HotelBookingSystem.Application.Features.ReservationRooms.Queries;
using HotelBookingSystem.Application.Interfaces;
using MediatR;
using HotelBookingSystem.Domain.Entities; // Assuming ReservationRoom entity is in this namespace
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.ReservationRooms.Handlers
{
    public class GetReservationRoomByIdQueryHandler : IRequestHandler<GetReservationRoomByIdQuery, ReservationRoomDto>
    {
        private readonly IReservationRoomRepository _reservationRoomRepository;
        private readonly IMapper _mapper;

        public GetReservationRoomByIdQueryHandler(IReservationRoomRepository reservationRoomRepository, IMapper mapper)
        {
            _reservationRoomRepository = reservationRoomRepository;
            _mapper = mapper;
        }

        public async Task<ReservationRoomDto> Handle(GetReservationRoomByIdQuery request, CancellationToken cancellationToken)
        {
            var reservationRoom = await _reservationRoomRepository.GetByIdAsync(request.Id);

            if (reservationRoom == null)
            {
                // Handle not found scenario, e.g., return null or throw a custom exception
                return null;
            }

            return _mapper.Map<ReservationRoomDto>(reservationRoom);
        }
    }
}