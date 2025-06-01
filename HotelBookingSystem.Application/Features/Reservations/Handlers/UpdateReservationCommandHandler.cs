csharp
using MediatR;
using HotelBookingSystem.Application.Features.Reservations.Commands;
using HotelBookingSystem.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Reservations.Handlers
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand, Unit>
    {
        private readonly IReservationRepository _reservationRepository;

        public UpdateReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Unit> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetByIdAsync(request.Id);

            if (reservation == null)
            {
                // Handle not found, possibly throw a custom exception
                return Unit.Value;
            }

            // Update reservation properties from the command
            // Example:
            // reservation.Status = request.Status;
            // reservation.Adults = request.Adults;
            // reservation.Children = request.Children;
            // ... update other properties as needed

            await _reservationRepository.UpdateAsync(reservation);

            return Unit.Value;
        }
    }
}