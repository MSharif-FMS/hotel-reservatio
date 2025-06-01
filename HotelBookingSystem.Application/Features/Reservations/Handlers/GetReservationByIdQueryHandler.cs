csharp
using MediatR;
using HotelBookingSystem.Application.Features.Reservations.Queries;
using HotelBookingSystem.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Reservations.Handlers
{
    public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, ReservationDto>
    {
        private readonly IReservationRepository _reservationRepository;

        public GetReservationByIdQueryHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<ReservationDto> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetByIdAsync(request.ReservationId);

            if (reservation == null)
            {
                return null; // Or throw a custom not found exception
            }

            // TODO: Implement mapping from Reservation entity to ReservationDto
            var reservationDto = new ReservationDto
            {
                // Map properties here
                Id = reservation.Id,
                ReservationNumber = reservation.ReservationNumber,
                UserId = reservation.UserId,
                Status = reservation.Status,
                Adults = reservation.Adults,
                Children = reservation.Children,
                SpecialRequests = reservation.SpecialRequests,
                PromoCode = reservation.PromoCode,
                TotalAmount = reservation.TotalAmount,
                TaxAmount = reservation.TaxAmount,
                NetAmount = reservation.NetAmount,
                Currency = reservation.Currency,
                Source = reservation.Source,
                IpAddress = reservation.IpAddress,
                CreatedAt = reservation.CreatedAt,
                UpdatedAt = reservation.UpdatedAt,
                // Include related data from navigation properties if needed in DTO
            };

            return reservationDto;
        }
    }
}