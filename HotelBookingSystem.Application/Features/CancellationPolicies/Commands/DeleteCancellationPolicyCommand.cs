csharp
namespace HotelBookingSystem.Application.Features.CancellationPolicies.Commands
{
    using MediatR;

    public class DeleteCancellationPolicyCommand : IRequest<bool>
    {
        public long PolicyId { get; set; }
    }
}