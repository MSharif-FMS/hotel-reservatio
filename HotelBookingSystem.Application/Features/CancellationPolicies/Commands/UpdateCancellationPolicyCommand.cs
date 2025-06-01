csharp
namespace HotelBookingSystem.Application.Features.CancellationPolicies.Commands
{
    public record UpdateCancellationPolicyCommand(
        long Id,
        string Name,
        string Description,
        int HoursBeforeCheckin,
        decimal PenaltyPercent,
        bool IsActive
    {
    }
}