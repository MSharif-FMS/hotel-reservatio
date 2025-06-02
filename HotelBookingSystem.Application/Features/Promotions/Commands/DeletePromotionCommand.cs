csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Promotions.Commands
{
    public class DeletePromotionCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}