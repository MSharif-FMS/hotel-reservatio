csharp
using MediatR;
using HotelBookingSystem.Application.Features.RatePlans.Commands;
using HotelBookingSystem.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace HotelBookingSystem.Application.Features.RatePlans.Handlers
{
    public class UpdateRatePlanCommandHandler : IRequestHandler<UpdateRatePlanCommand, bool>
    {
        private readonly IRatePlanRepository _ratePlanRepository;

        public UpdateRatePlanCommandHandler(IRatePlanRepository ratePlanRepository)
        {
            _ratePlanRepository = ratePlanRepository;
        }

        public async Task<bool> Handle(UpdateRatePlanCommand request, CancellationToken cancellationToken)
        {
            var ratePlan = await _ratePlanRepository.GetByIdAsync(request.Id);

            if (ratePlan == null)
            {
                return false; // Rate plan not found
            }

            // Update properties
            ratePlan.Name = request.Name;
            ratePlan.Description = request.Description;
            ratePlan.CancellationPolicyId = request.CancellationPolicyId;
            ratePlan.IsBreakfastIncluded = request.IsBreakfastIncluded;
            ratePlan.IsRefundable = request.IsRefundable;
            ratePlan.MinStay = request.MinStay;
            ratePlan.MaxStay = request.MaxStay;
            ratePlan.AdvanceBookingDays = request.AdvanceBookingDays;
            ratePlan.IsActive = request.IsActive;
            ratePlan.UpdatedAt = DateTimeOffset.UtcNow; // Update timestamp

            return await _ratePlanRepository.UpdateAsync(ratePlan);
        }
    }
}