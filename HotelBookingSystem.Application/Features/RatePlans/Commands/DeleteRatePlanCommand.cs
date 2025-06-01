csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.RatePlans.Commands;

public class DeleteRatePlanCommand : IRequest<bool>
{
    // Include property for the rate plan ID to be deleted.
    public long RatePlanId { get; set; }
}