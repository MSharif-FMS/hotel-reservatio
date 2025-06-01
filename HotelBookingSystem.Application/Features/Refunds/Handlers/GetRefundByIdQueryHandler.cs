csharp
using MediatR;
using HotelBookingSystem.Application.Features.Refunds.Queries;
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Refunds.Handlers
{
    public class GetRefundByIdQueryHandler : IRequestHandler<GetRefundByIdQuery, RefundDto>
    {
        private readonly IRefundRepository _refundRepository;

        public GetRefundByIdQueryHandler(IRefundRepository refundRepository)
        {
            _refundRepository = refundRepository;
        }

        public async Task<RefundDto> Handle(GetRefundByIdQuery request, CancellationToken cancellationToken)
        {
            var refund = await _refundRepository.GetByIdAsync(request.RefundId);

            if (refund == null)
            {
                return null;
            }

            // Map the Refund entity to RefundDto (you would typically use AutoMapper here)
            var refundDto = new RefundDto
            {
                Id = refund.Id,
                PaymentId = refund.PaymentId,
                Amount = refund.Amount,
                Reason = refund.Reason,
                ProcessedBy = refund.ProcessedBy,
                Status = refund.Status,
                CreatedAt = refund.CreatedAt,
                UpdatedAt = refund.UpdatedAt
            };

            return refundDto;
        }
    }
}