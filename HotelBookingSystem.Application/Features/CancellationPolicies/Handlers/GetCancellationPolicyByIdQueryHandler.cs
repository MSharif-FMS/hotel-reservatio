csharp
using MediatR;
using HotelBookingSystem.Application.Features.CancellationPolicies.Queries;
using HotelBookingSystem.Application.Features.CancellationPolicies.Responses; // Assuming you have a Responses folder for DTOs
using HotelBookingSystem.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using HotelBookingSystem.Domain.Entities; // Assuming CancellationPolicy is in Domain.Entities

namespace HotelBookingSystem.Application.Features.CancellationPolicies.Handlers
{
    public class GetCancellationPolicyByIdQueryHandler : IRequestHandler<GetCancellationPolicyByIdQuery, CancellationPolicyDto>
    {
        private readonly ICancellationPolicyRepository _cancellationPolicyRepository;

        public GetCancellationPolicyByIdQueryHandler(ICancellationPolicyRepository cancellationPolicyRepository)
        {
            _cancellationPolicyRepository = cancellationPolicyRepository;
        }

        public async Task<CancellationPolicyDto> Handle(GetCancellationPolicyByIdQuery request, CancellationToken cancellationToken)
        {
            CancellationPolicy policy = await _cancellationPolicyRepository.GetByIdAsync(request.Id);

            if (policy == null)
            {
                return null; // Or throw a not found exception
            }

            // Map the entity to the DTO
            var policyDto = new CancellationPolicyDto
            {
                Id = policy.Id,
                Name = policy.Name,
                Description = policy.Description,
                HoursBeforeCheckin = policy.HoursBeforeCheckin,
                PenaltyPercent = policy.PenaltyPercent
            };

            return policyDto;
        }
    }
}