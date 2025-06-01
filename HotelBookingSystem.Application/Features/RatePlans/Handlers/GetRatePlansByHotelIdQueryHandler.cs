csharp
using HotelBookingSystem.Application.Features.RatePlans.Queries;
using HotelBookingSystem.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.RatePlans.Handlers
{
    public class GetRatePlansByHotelIdQueryHandler : IRequestHandler<GetRatePlansByHotelIdQuery, IEnumerable<RatePlanDto>>
    {
        private readonly IRatePlanRepository _ratePlanRepository;

        public GetRatePlansByHotelIdQueryHandler(IRatePlanRepository ratePlanRepository)
        {
            _ratePlanRepository = ratePlanRepository;
        }

        public async Task<IEnumerable<RatePlanDto>> Handle(GetRatePlansByHotelIdQuery request, CancellationToken cancellationToken)
        {
            var ratePlans = await _ratePlanRepository.GetByHotelIdAsync(request.HotelId);

            // Map to DTOs (assuming a simple mapping for now)
            var ratePlanDtos = ratePlans.Select(rp => new RatePlanDto
            {
                Id = rp.Id,
                HotelId = rp.HotelId,
                Name = rp.Name,
                Description = rp.Description,
                IsBreakfastIncluded = rp.IsBreakfastIncluded,
                IsRefundable = rp.IsRefundable,
                MinStay = rp.MinStay,
                MaxStay = rp.MaxStay
                // Map other properties as needed
            }).ToList();

            return ratePlanDtos;
        }
    }
}