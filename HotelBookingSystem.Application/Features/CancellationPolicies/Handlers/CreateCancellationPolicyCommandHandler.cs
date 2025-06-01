csharp
using MediatR;
using HotelBookingSystem.Application.Features.CancellationPolicies.Commands;
using HotelBookingSystem.Domain.Entities;
using HotelBookingSystem.Domain.Interfaces;

namespace HotelBookingSystem.Application.Features.CancellationPolicies.Handlers
{
    public class CreateCancellationPolicyCommandHandler : IRequestHandler<CreateCancellationPolicyCommand, long>
    {
        private readonly ICancellationPolicyRepository _cancellationPolicyRepository;

        public CreateCancellationPolicyCommandHandler(ICancellationPolicyRepository cancellationPolicyRepository)
        {
            _cancellationPolicyRepository = cancellationPolicyRepository;
        }

        public async Task<long> Handle(CreateCancellationPolicyCommand request, CancellationToken cancellationToken)
        {
            var policy = new CancellationPolicy
            {
                Name = request.Name,
                Description = request.Description,
                HoursBeforeCheckin = request.HoursBeforeCheckin,
                PenaltyPercent = request.PenaltyPercent,
                IsActive = true, // Assuming active by default on creation
                CreatedAt = DateTimeOffset.UtcNow
            };

            await _cancellationPolicyRepository.AddAsync(policy);

            return policy.Id;
        }
    }
}