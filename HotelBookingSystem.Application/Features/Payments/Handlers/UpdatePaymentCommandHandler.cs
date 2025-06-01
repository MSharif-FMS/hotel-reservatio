csharp
using MediatR;
using HotelBookingSystem.Application.Features.Payments.Commands;
using HotelBookingSystem.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic; // Added for KeyNotFoundException

namespace HotelBookingSystem.Application.Features.Payments.Handlers
{
    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, Unit>
    {
        private readonly IPaymentRepository _paymentRepository;

        public UpdatePaymentCommandHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Unit> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = await _paymentRepository.GetByIdAsync(request.Id);

            if (payment == null)
            {
                // Handle not found exception
                throw new KeyNotFoundException($"Payment with id {request.Id} not found.");
            }

            // Update payment properties
            payment.Status = request.Status;
            payment.ReceiptUrl = request.ReceiptUrl;
            // Update other properties as needed

            await _paymentRepository.UpdateAsync(payment);

            return Unit.Value;
        }
    }
}