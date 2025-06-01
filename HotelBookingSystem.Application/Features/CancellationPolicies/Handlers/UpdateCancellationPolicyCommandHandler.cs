csharp
using HotelBookingSystem.Application.Features.CancellationPolicies.Commands;
using HotelBookingSystem.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.CancellationPolicies.Handlers
{
    public class UpdateCancellationPolicyCommandHandler : IRequestHandler<UpdateCancellationPolicyCommand, bool>
    {
        private readonly ICancellationPolicyRepository _cancellationPolicyRepository;

        public UpdateCancellationPolicyCommandHandler(ICancellationPolicyRepository cancellationPolicyRepository)
        {
            _cancellationPolicyRepository = cancellationPolicyRepository;
        }

        public async Task<bool> Handle(UpdateCancellationPolicyCommand request, CancellationToken cancellationToken)
        {
            var policy = await _cancellationPolicyRepository.GetByIdAsync(request.Id);

            if (policy == null)
            {
                return false; // Or throw a NotFoundException
            }

            // Update properties based on the command

            policy.Name = request.Name;
            policy.Description = request.Description;
            policy.HoursBeforeCheckin = request.HoursBeforeCheckin;
            policy.PenaltyPercent = request.PenaltyPercent;
            policy.IsActive = request.IsActive; // Assuming IsActive can be updated

            return await _cancellationPolicyRepository.UpdateAsync(policy);
        }
    }
}
