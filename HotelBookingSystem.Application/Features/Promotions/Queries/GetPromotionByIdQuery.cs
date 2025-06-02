csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Promotions.Queries
{
    public class GetPromotionByIdQuery : IRequest<PromotionDto>
    {
        public long Id { get; set; }
    }
}