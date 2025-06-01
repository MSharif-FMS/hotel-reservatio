csharp
using MediatR;
using System.Collections.Generic;

namespace HotelBookingSystem.Application.Features.Refunds.Queries
{
    public class GetRefundsByPaymentIdQuery : IRequest<IEnumerable<RefundDto>>
    {
        public long PaymentId { get; set; }
    }
}