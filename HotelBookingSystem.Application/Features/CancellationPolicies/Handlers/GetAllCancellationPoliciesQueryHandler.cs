csharp
using HotelBookingSystem.Application.Features.CancellationPolicies.Queries;
using HotelBookingSystem.Domain.Interfaces;
using MediatR;
using HotelBookingSystem.Application.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.CancellationPolicies.Handlers
{
    public class GetAllCancellationPoliciesQueryHandler : IRequestHandler<GetAllCancellationPoliciesQuery, IEnumerable<CancellationPolicyDto>>
    {
        private readonly ICancellationPolicyRepository _cancellationPolicyRepository;

        public GetAllCancellationPoliciesQueryHandler(ICancellationPolicyRepository cancellationPolicyRepository)
        {
            _cancellationPolicyRepository = cancellationPolicyRepository;
        }

        public async Task<IEnumerable<CancellationPolicyDto>> Handle(GetAllCancellationPoliciesQuery request, CancellationToken cancellationToken)
        {
            var policies = await _cancellationPolicyRepository.GetAllAsync();

            return policies.Select(p => new CancellationPolicyDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                HoursBeforeCheckin = p.HoursBeforeCheckin,
                PenaltyPercent = p.PenaltyPercent
            }).ToList();
        }
    }
}