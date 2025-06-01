csharp
using HotelBookingSystem.Application.Features.RatePlans.Queries;
using HotelBookingSystem.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.RatePlans.Handlers
{
    public class GetAllRatePlansQueryHandler : IRequestHandler<GetAllRatePlansQuery, IEnumerable<RatePlanDto>>
    {
        private readonly IRatePlanRepository _ratePlanRepository;

        public GetAllRatePlansQueryHandler(IRatePlanRepository ratePlanRepository)
        {
            _ratePlanRepository = ratePlanRepository;
        }

        public async Task<IEnumerable<RatePlanDto>> Handle(GetAllRatePlansQuery request, CancellationToken cancellationToken)
        {
            var ratePlans = await _ratePlanRepository.GetAllAsync();

            return ratePlans.Select(rp => new RatePlanDto
            {
                Id = rp.Id,
                HotelId = rp.HotelId,
                Name = rp.Name, // Assuming Name is a property
                Description = rp.Description, // Assuming Description is a property
                IsBreakfastIncluded = rp.IsBreakfastIncluded,
                IsRefundable = rp.IsRefundable,
                MinStay = rp.MinStay,
                MaxStay = rp.MaxStay
                // Map other properties as needed
            });
        }
    }
}