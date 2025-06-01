csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.RoomTypes.Commands
{

    public class UpdateRoomTypeCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public long HotelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BaseCapacity { get; set; }
        public int MaxCapacity { get; set; }
        public decimal BasePrice { get; set; }
        public int? SizeSqft { get; set; }
        public string BedConfiguration { get; set; }
        public string[] Amenities { get; set; }
        public bool IsActive { get; set; }
    }
}