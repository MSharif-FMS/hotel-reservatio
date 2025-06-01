csharp
namespace HotelBookingSystem.Application.Features.Users.Queries
{
    public class UserDto
    {
        public long Id { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
    }
}