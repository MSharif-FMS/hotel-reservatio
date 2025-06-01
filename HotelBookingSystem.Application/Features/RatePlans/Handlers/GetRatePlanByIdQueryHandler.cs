csharp
using MediatR;
using HotelBookingSystem.Application.Features.RatePlans.Queries;
using HotelBookingSystem.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.RatePlans.Handlers
{
    public class GetRatePlanByIdQueryHandler : IRequestHandler<GetRatePlanByIdQuery, RatePlanDto>
    {
        private readonly IRatePlanRepository _ratePlanRepository;

        public GetRatePlanByIdQueryHandler(IRatePlanRepository ratePlanRepository)
        {
            _ratePlanRepository = ratePlanRepository;
        }

        public async Task<RatePlanDto> Handle(GetRatePlanByIdQuery request, CancellationToken cancellationToken)
        {
            var ratePlan = await _ratePlanRepository.GetByIdAsync(request.Id);

            if (ratePlan == null)
            {
                return null; // Or throw a custom not found exception
            } // Consider adding a custom exception for not found scenarios.

            // Map the RatePlan entity to RatePlanDto
            var ratePlanDto = new RatePlanDto
            {
                Id = ratePlan.Id,
                HotelId = ratePlan.HotelId,
                Name = ratePlan.Name,
                Description = ratePlan.Description,
                IsBreakfastIncluded = ratePlan.IsBreakfastIncluded,
                IsRefundable = ratePlan.IsRefundable,
                MinStay = ratePlan.MinStay,
                MaxStay = ratePlan.MaxStay,
                // Add other properties as needed
            };

            return ratePlanDto;
        }
    }
}