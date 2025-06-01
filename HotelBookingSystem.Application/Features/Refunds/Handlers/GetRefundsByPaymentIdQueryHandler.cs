csharp
using MediatR;
using HotelBookingSystem.Application.Features.Refunds.Queries;
using HotelBookingSystem.Application.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Refunds.Handlers
{
    public class GetRefundsByPaymentIdQueryHandler : IRequestHandler<GetRefundsByPaymentIdQuery, IEnumerable<RefundDto>>
    {
        private readonly IRefundRepository _refundRepository;

        public GetRefundsByPaymentIdQueryHandler(IRefundRepository refundRepository)
        {
            _refundRepository = refundRepository;
        }

        public async Task<IEnumerable<RefundDto>> Handle(GetRefundsByPaymentIdQuery request, CancellationToken cancellationToken)
        {
            // In a real application, you would fetch the refunds using the repository and map them to RefundDto objects.
            // For now, we'll return an empty list.
            return System.Linq.Enumerable.Empty<RefundDto>();
        }
    }
}