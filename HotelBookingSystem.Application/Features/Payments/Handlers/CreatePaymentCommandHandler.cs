csharp
using MediatR;
using HotelBookingSystem.Application.Features.Payments.Commands;
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Payments.Handlers
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, long>
    {
        private readonly IPaymentRepository _paymentRepository;

        public CreatePaymentCommandHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<long> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = new Payment
            {
                ReservationId = request.ReservationId,
                Amount = request.Amount,
                Currency = request.Currency, // Assuming Currency is included in the command
                PaymentMethod = request.PaymentMethod,
                PaymentGateway = request.PaymentGateway, // Assuming PaymentGateway is included
                TransactionId = request.TransactionId,
                Status = "pending", // Initial status
                CardLast4 = request.CardLast4, // Assuming CardLast4 is included
                CardBrand = request.CardBrand, // Assuming CardBrand is included
                Created_at = DateTimeOffset.UtcNow,
                Updated_at = DateTimeOffset.UtcNow
            };

            await _paymentRepository.AddAsync(payment);

            return payment.Id;
        }
    }
}