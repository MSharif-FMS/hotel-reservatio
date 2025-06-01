csharp
using HotelBookingSystem.Application.Features.Payments.Queries;
using HotelBookingSystem.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Payments.Handlers
{
    public class GetPaymentByIdQueryHandler : IRequestHandler<GetPaymentByIdQuery, PaymentDto>
    {
        private readonly IPaymentRepository _paymentRepository;

        public GetPaymentByIdQueryHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<PaymentDto> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
        {
            var payment = await _paymentRepository.GetByIdAsync(request.PaymentId);

            if (payment == null)
            {
                // Handle not found, perhaps return null or throw a specific exception
                return null; 
            }

            // TODO: Map the Payment entity to PaymentDto
            var paymentDto = new PaymentDto 
            {
                Id = payment.Id,
                ReservationId = payment.ReservationId,
                Amount = payment.Amount,
                Currency = payment.Currency,
                PaymentMethod = payment.PaymentMethod,
                PaymentGateway = payment.PaymentGateway,
                TransactionId = payment.TransactionId,
                Status = payment.Status,
                CardLast4 = payment.CardLast4,
                CardBrand = payment.CardBrand,
                ReceiptUrl = payment.ReceiptUrl,
                CapturedAt = payment.CapturedAt,
                CreatedAt = payment.CreatedAt,
                UpdatedAt = payment.UpdatedAt
            };

            return paymentDto;
        }
    }
}