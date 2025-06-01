csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Guests.Commands
{
    public class CreateGuestCommand : IRequest<long>
    {
        public long ReservationRoomId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? IdType { get; set; }
        public string? IdNumber { get; set; }
        public string? Nationality { get; set; }
        public bool IsPrimary { get; set; }
    }
}