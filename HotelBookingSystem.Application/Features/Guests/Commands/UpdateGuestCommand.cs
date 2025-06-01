csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Guests.Commands
{
    public class UpdateGuestCommand : IRequest<Unit>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string IdType { get; set; }
        public string IdNumber { get; set; }
        public string Nationality { get; set; }
        public bool IsPrimary { get; set; }
    }
}