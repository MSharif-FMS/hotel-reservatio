csharp
namespace HotelBookingSystem.Application.Features.RoomPricing.Queries
{
    public class GetRoomPricingByIdQuery : IRequest<RoomPricingDto>
    {
        public long Id { get; set; }
    }
}