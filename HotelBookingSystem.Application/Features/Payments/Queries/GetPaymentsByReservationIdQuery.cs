csharp
using MediatR;
using System.Collections.Generic;

namespace HotelBookingSystem.Application.Features.Payments.Queries
{
    public class GetPaymentsByReservationIdQuery : IRequest<IEnumerable<PaymentDto>>
    {
        public long ReservationId { get; set; }
    }
}