csharp
using MediatR;
using HotelBookingSystem.Application.Features.Refunds.Commands;
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace HotelBookingSystem.Application.Features.Refunds.Handlers
{
    public class CreateRefundCommandHandler : IRequestHandler<CreateRefundCommand, long>
    {
        private readonly IRefundRepository _refundRepository;

        public CreateRefundCommandHandler(IRefundRepository refundRepository)
        {
            _refundRepository = refundRepository;
        }

        public async Task<long> Handle(CreateRefundCommand request, CancellationToken cancellationToken)
        {
            var refund = new Refund
            {
                PaymentId = request.PaymentId,
                Amount = request.Amount,
                Reason = request.Reason,
                ProcessedBy = request.ProcessedBy,
                Status = request.Status,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow
            };

            await _refundRepository.AddAsync(refund);

            return refund.Id;
        }
    }
}