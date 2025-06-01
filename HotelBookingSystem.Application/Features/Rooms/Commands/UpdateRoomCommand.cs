csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Rooms.Commands
{
    public class UpdateRoomCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public long HotelId { get; set; }
        public long RoomTypeId { get; set; }
        public string RoomNumber { get; set; }
        public int FloorNumber { get; set; }
        public string? ViewType { get; set; }
        public bool? IsSmoking { get; set; }
        public bool? IsAccessible { get; set; }
        public bool? IsActive { get; set; }
    }
}