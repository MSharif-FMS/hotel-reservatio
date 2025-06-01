csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.CancellationPolicies.Commands;

public class CreateCancellationPolicyCommand : IRequest<long>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int HoursBeforeCheckin { get; set; }
    public long HotelId { get; set; }
    public int PenaltyPercent { get; set; }
}