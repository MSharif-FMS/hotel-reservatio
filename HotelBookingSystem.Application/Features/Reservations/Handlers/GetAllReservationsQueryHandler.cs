csharp
using HotelBookingSystem.Application.Features.Reservations.Queries;
using HotelBookingSystem.Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Reservations.Handlers
{
    public class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, IEnumerable<ReservationDto>>
    {
        private readonly IReservationRepository _reservationRepository;

        public GetAllReservationsQueryHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<ReservationDto>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _reservationRepository.GetAllAsync();

            // In a real application, you would use a library like AutoMapper for this mapping.
            // For simplicity, we'll do basic mapping here.
            var reservationDtos = new List<ReservationDto>();
            foreach (var reservation in reservations)
            {
                reservationDtos.Add(new ReservationDto
                {
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
                    UpdatedAt = reservation.UpdatedAt
                    // You would also map ReservationRooms here if needed
                });
            }

            return reservationDtos;
        }
    }
}