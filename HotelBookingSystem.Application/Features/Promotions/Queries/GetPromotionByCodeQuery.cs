csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Promotions.Queries
{
    public class GetPromotionByCodeQuery : IRequest<PromotionDto>
    {
        public string Code { get; set; }
    }
}