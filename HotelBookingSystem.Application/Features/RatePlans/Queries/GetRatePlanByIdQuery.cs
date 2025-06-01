csharp
namespace HotelBookingSystem.Application.Features.RatePlans.Queries
{
    using MediatR;

    public class GetRatePlanByIdQuery : IRequest<RatePlanDto>
    {
 public long RatePlanId { get; set; }
    }
}