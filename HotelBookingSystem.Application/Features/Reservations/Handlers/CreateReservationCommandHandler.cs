csharp
using HotelBookingSystem.Application.Features.Reservations.Commands;
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Reservations.Handlers
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, long>
    {
        private readonly IReservationRepository _reservationRepository;
        // Inject other necessary dependencies (e.g., for pricing, availability)

        public CreateReservationCommandHandler(IReservationRepository reservationRepository /*, other dependencies */)
        {
            _reservationRepository = reservationRepository;
            // Initialize other dependencies
        }

        public async Task<long> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            // Implement logic to calculate total amount, tax, net amount, check availability, etc.
            // This would involve using injected services/repositories

            var reservation = new Reservation
            {
                UserId = request.UserId,
                Status = "pending", // Initial status
                Adults = request.Adults,
                Children = request.Children,
                SpecialRequests = request.SpecialRequests,
                PromoCode = request.PromoCode,
                // Calculate and set TotalAmount, TaxAmount, NetAmount
                TotalAmount = 0, // Placeholder
                TaxAmount = 0, // Placeholder
                NetAmount = 0, // Placeholder
                Currency = request.Currency ?? "USD",
                Source = request.Source ?? "website",
                IpAddress = request.IpAddress,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow
            };

            // Add reservation rooms logic here based on request.RoomDetails
            // This would involve creating ReservationRoom entities and linking them

            await _reservationRepository.AddAsync(reservation);

            // Potentially publish a Domain Event here (e.g., ReservationCreatedEvent)

            return reservation.Id;
        }
    }
}