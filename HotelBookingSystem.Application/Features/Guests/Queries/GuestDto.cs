csharp
namespace HotelBookingSystem.Application.Features.Guests.Queries
{
    public class GuestDto
    {
        public long Id { get; set; }
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