csharp
namespace HotelBookingSystem.Application.Features.Refunds.Queries
{
    public class GetRefundByIdQuery : IRequest<RefundDto>
    {
        public long Id { get; set; }
    }
}