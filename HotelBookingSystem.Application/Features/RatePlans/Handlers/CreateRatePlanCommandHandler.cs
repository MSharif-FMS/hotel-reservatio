csharp
using HotelBookingSystem.Application.Features.RatePlans.Commands;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.RatePlans.Handlers
{
    public class CreateRatePlanCommandHandler : IRequestHandler<CreateRatePlanCommand, long>
    {
        private readonly IRatePlanRepository _ratePlanRepository;

        public CreateRatePlanCommandHandler(IRatePlanRepository ratePlanRepository)
        {
            _ratePlanRepository = ratePlanRepository;
        }

        public async Task<long> Handle(CreateRatePlanCommand request, CancellationToken cancellationToken)
        {
            var ratePlan = new RatePlan
            {
                HotelId = request.HotelId,
                Name = request.Name,
                Description = request.Description,
                CancellationPolicyId = request.CancellationPolicyId,
                IsBreakfastIncluded = request.IsBreakfastIncluded,
                IsRefundable = request.IsRefundable,
                MinStay = request.MinStay,
                MaxStay = request.MaxStay,
                AdvanceBookingDays = request.AdvanceBookingDays,
                IsActive = request.IsActive,
                CreatedAt = System.DateTimeOffset.UtcNow,
                UpdatedAt = System.DateTimeOffset.UtcNow
            };

            await _ratePlanRepository.AddAsync(ratePlan);
            return ratePlan.Id;
        }
    }
}