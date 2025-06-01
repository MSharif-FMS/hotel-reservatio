csharp
using MediatR;
using HotelBookingSystem.Application.Features.ReservationRooms.Commands;
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.ReservationRooms.Handlers
{
    public class CreateReservationRoomCommandHandler : IRequestHandler<CreateReservationRoomCommand, long>
    {
        private readonly IReservationRoomRepository _reservationRoomRepository;

        public CreateReservationRoomCommandHandler(IReservationRoomRepository reservationRoomRepository)
        {
            _reservationRoomRepository = reservationRoomRepository;
        }

        public async Task<long> Handle(CreateReservationRoomCommand request, CancellationToken cancellationToken)
        {
            var reservationRoom = new ReservationRoom
            {
                ReservationId = request.ReservationId,
                RoomId = request.RoomId,
                RatePlanId = request.RatePlanId,
                CheckInDate = request.CheckInDate,
                CheckOutDate = request.CheckOutDate,
                Adults = request.Adults,
                Children = request.Children,
                PricePerNight = request.PricePerNight,
                Status = "reserved", // Default status
                SpecialRequests = request.SpecialRequests,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow
            };

            await _reservationRoomRepository.AddAsync(reservationRoom);
            // Depending on your repository implementation, you might need a SaveChangesAsync here
            // await _reservationRoomRepository.SaveChangesAsync(); 

            return reservationRoom.Id;
        }
    }
}