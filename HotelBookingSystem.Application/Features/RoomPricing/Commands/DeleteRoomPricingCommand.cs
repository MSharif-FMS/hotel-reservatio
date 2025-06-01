csharp
namespace HotelBookingSystem.Application.Features.RoomPricing.Commands
{
    public class DeleteRoomPricingCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}