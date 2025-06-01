csharp
using MediatR;
using HotelBookingSystem.Application.Features.Reservations.Queries;
using HotelBookingSystem.Application.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Reservations.Handlers
{
    public class GetReservationsByUserIdQueryHandler : IRequestHandler<GetReservationsByUserIdQuery, IEnumerable<ReservationDto>>
    {
        private readonly IReservationRepository _reservationRepository;

        public GetReservationsByUserIdQueryHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<ReservationDto>> Handle(GetReservationsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _reservationRepository.GetReservationsByUserIdAsync(request.UserId);

            // In a real application, you would use a mapper like AutoMapper
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
                    // Map other properties and nested objects as needed
                });
            }

            return reservationDtos;
        }
    }
}