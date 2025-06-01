csharp
using MediatR;
using HotelBookingSystem.Application.Features.ReservationRooms.Commands;
using HotelBookingSystem.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.Features.ReservationRooms.Handlers
{
    public class UpdateReservationRoomCommandHandler : IRequestHandler<UpdateReservationRoomCommand, Unit>
    {
        private readonly IReservationRoomRepository _reservationRoomRepository;

        public UpdateReservationRoomCommandHandler(IReservationRoomRepository reservationRoomRepository)
        {
            _reservationRoomRepository = reservationRoomRepository;
        }

        public async Task<Unit> Handle(UpdateReservationRoomCommand request, CancellationToken cancellationToken)
        {
            var reservationRoom = await _reservationRoomRepository.GetByIdAsync(request.Id);

            if (reservationRoom == null)
            {
                // Handle not found scenario (e.g., throw an exception)
                throw new System.Exception($"ReservationRoom with ID {request.Id} not found.");
            }

            // Update properties based on the command request
            reservationRoom.RoomId = request.RoomId;
            reservationRoom.RatePlanId = request.RatePlanId;
            reservationRoom.CheckInDate = request.CheckInDate;
            reservationRoom.CheckOutDate = request.CheckOutDate;
            reservationRoom.Adults = request.Adults;
            reservationRoom.Children = request.Children;
            reservationRoom.PricePerNight = request.PricePerNight;
            reservationRoom.Status = request.Status;
            reservationRoom.SpecialRequests = request.SpecialRequests;
            reservationRoom.UpdatedAt = DateTimeOffset.UtcNow; // Assuming you want to update the UpdatedAt timestamp

            await _reservationRoomRepository.UpdateAsync(reservationRoom);

            return Unit.Value;
        }
    }
}