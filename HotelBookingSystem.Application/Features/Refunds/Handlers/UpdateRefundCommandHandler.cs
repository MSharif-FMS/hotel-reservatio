csharp
using AutoMapper;
using HotelBookingSystem.Application.Features.Refunds.Commands;
using HotelBookingSystem.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Refunds.Handlers
{
    public class UpdateRefundCommandHandler : IRequestHandler<UpdateRefundCommand, Unit>
    {
        private readonly IRefundRepository _refundRepository;
        private readonly IMapper _mapper;

        public UpdateRefundCommandHandler(IRefundRepository refundRepository, IMapper mapper)
        {
            _refundRepository = refundRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateRefundCommand request, CancellationToken cancellationToken) // Implementing the Handle method
        {
            var refund = await _refundRepository.GetByIdAsync(request.Id);

            if (refund == null)
            {
                // Handle not found, potentially throw a custom exception
                return Unit.Value;
            }

            _mapper.Map(request, refund);

            await _refundRepository.UpdateAsync(refund);

            return Unit.Value;
        }
    }
}