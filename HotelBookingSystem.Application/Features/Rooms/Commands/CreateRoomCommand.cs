csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Rooms.Commands
{
    public class CreateRoomCommand : IRequest<long>
    {
        public long HotelId { get; set; }
        public long RoomTypeId { get; set; }
        public string RoomNumber { get; set; }
        public int FloorNumber { get; set; }
        public string RoomName { get; set; }
        public string? ViewType { get; set; }
        public bool IsSmoking { get; set; }
        public bool IsAccessible { get; set; }
    }
}