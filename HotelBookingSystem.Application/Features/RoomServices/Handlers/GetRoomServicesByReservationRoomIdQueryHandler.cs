csharp
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Application.Features.RoomServices.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.RoomServices.Handlers
{
    public class GetRoomServicesByReservationRoomIdQueryHandler : IRequestHandler<GetRoomServicesByReservationRoomIdQuery, IEnumerable<RoomServiceDto>>
    {
        private readonly IRoomServiceRepository _roomServiceRepository;

        public GetRoomServicesByReservationRoomIdQueryHandler(IRoomServiceRepository roomServiceRepository)
        {
            _roomServiceRepository = roomServiceRepository;
        }

        public async Task<IEnumerable<RoomServiceDto>> Handle(GetRoomServicesByReservationRoomIdQuery request, CancellationToken cancellationToken)
        {
            var roomServices = await _roomServiceRepository.GetRoomServicesByReservationRoomIdAsync(request.ReservationRoomId);

            // In a real application, you would map the entities to DTOs here
            var roomServiceDtos = new List<RoomServiceDto>();
            foreach (var rs in roomServices)
            {
                roomServiceDtos.Add(new RoomServiceDto
                {
                    Id = rs.Id,
                    ReservationRoomId = rs.ReservationRoomId,
                    ServiceId = rs.ServiceId,
                    Quantity = rs.Quantity,
                    RequestedTime = rs.RequestedTime,
                    Status = rs.Status,
                    Notes = rs.Notes,
                    CreatedAt = rs.CreatedAt,
                    UpdatedAt = rs.UpdatedAt
                });
            }

            return roomServiceDtos;
        }
    }
}