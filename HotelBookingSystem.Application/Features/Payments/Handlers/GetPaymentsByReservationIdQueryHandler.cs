csharp
using HotelBookingSystem.Application.Features.Payments.Queries;
using HotelBookingSystem.Application.Interfaces;
using MediatR;

namespace HotelBookingSystem.Application.Features.Payments.Handlers
{
    public class GetPaymentsByReservationIdQueryHandler : IRequestHandler<GetPaymentsByReservationIdQuery, IEnumerable<PaymentDto>>
    {
        private readonly IPaymentRepository _paymentRepository;

        public GetPaymentsByReservationIdQueryHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<IEnumerable<PaymentDto>> Handle(GetPaymentsByReservationIdQuery request, CancellationToken cancellationToken)
        {
            var payments = await _paymentRepository.GetPaymentsByReservationIdAsync(request.ReservationId, cancellationToken);

            // Map the entities to DTOs (Assuming a mapping library like AutoMapper is used or manual mapping)
            var paymentDtos = payments.Select(p => new PaymentDto
            {
                Id = p.Id,
                ReservationId = p.ReservationId,
                Amount = p.Amount,
                Currency = p.Currency,
                PaymentMethod = p.PaymentMethod,
                PaymentGateway = p.PaymentGateway,
                TransactionId = p.TransactionId,
                Status = p.Status,
                CardLast4 = p.CardLast4,
                CardBrand = p.CardBrand,
                ReceiptUrl = p.ReceiptUrl,
                CapturedAt = p.CapturedAt,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            });

            return paymentDtos;
        }
    }
}