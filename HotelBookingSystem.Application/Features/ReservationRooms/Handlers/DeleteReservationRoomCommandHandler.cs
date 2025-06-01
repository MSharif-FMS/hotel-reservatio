csharp
using MediatR;
using HotelBookingSystem.Application.Features.ReservationRooms.Commands;
using HotelBookingSystem.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.ReservationRooms.Handlers
{
    public class DeleteReservationRoomCommandHandler : IRequestHandler<DeleteReservationRoomCommand, Unit>
    {
        private readonly IReservationRoomRepository _reservationRoomRepository;

        public DeleteReservationRoomCommandHandler(IReservationRoomRepository reservationRoomRepository)
        {
            _reservationRoomRepository = reservationRoomRepository;
        }

        public async Task<Unit> Handle(DeleteReservationRoomCommand request, CancellationToken cancellationToken)
        {
            var reservationRoom = await _reservationRoomRepository.GetByIdAsync(request.Id);

            if (reservationRoom == null)
            {
                // Handle not found scenario, e.g., throw an exception
                // throw new NotFoundException(nameof(ReservationRoom), request.Id);
                return Unit.Value;
            }

            await _reservationRoomRepository.DeleteAsync(reservationRoom);

            return Unit.Value;
        }
    }
}