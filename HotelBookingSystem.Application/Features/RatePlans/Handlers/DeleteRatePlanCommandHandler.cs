csharp
using HotelBookingSystem.Application.Features.RatePlans.Commands;
using HotelBookingSystem.Domain.Interfaces;
using MediatR;

namespace HotelBookingSystem.Application.Features.RatePlans.Handlers
{
    public class DeleteRatePlanCommandHandler : IRequestHandler<DeleteRatePlanCommand, bool>
    {
        private readonly IRatePlanRepository _ratePlanRepository;

        public DeleteRatePlanCommandHandler(IRatePlanRepository ratePlanRepository)
        {
            _ratePlanRepository = ratePlanRepository;
        }

        public async Task<bool> Handle(DeleteRatePlanCommand request, CancellationToken cancellationToken)
        {
            return await _ratePlanRepository.DeleteAsync(request.Id);
        }
    }
}