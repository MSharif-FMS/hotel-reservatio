csharp
namespace HotelBookingSystem.Application.Features.RoomPricing.Commands
{
    public class UpdateRoomPricingCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public long RoomTypeId { get; set; }
        public long RatePlanId { get; set; }
        public DateTimeOffset Date { get; set; }
        public decimal Price { get; set; }
        public int AvailableRooms { get; set; }
        public int? MinStay { get; set; }
        public bool StopSell { get; set; }
    }
}