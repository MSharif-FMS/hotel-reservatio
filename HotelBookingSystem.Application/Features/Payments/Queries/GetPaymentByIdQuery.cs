csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Payments.Queries
{
    public class GetPaymentByIdQuery : IRequest<PaymentDto>
    {
        public long Id { get; set; }
    }
}