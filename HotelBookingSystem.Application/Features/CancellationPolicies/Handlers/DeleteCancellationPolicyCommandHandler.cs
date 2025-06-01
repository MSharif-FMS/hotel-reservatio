csharp
using MediatR;
using HotelBookingSystem.Application.Features.CancellationPolicies.Commands;
using HotelBookingSystem.Domain.Interfaces;

namespace HotelBookingSystem.Application.Features.CancellationPolicies.Handlers
{
    public class DeleteCancellationPolicyCommandHandler : IRequestHandler<DeleteCancellationPolicyCommand, bool>
    {
        private readonly ICancellationPolicyRepository _cancellationPolicyRepository;

        public DeleteCancellationPolicyCommandHandler(ICancellationPolicyRepository cancellationPolicyRepository)
        {
            _cancellationPolicyRepository = cancellationPolicyRepository;
        }

        public async Task<bool> Handle(DeleteCancellationPolicyCommand request, CancellationToken cancellationToken)
        {
            // In a real application, you would add validation and error handling here
            // e.g., check if the cancellation policy exists before attempting to delete

            return await _cancellationPolicyRepository.DeleteAsync(request.PolicyId);
        }
    }
}