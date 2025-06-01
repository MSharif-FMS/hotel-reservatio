csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Hotels.Commands
{
    public class UpdateHotelCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Address { get; set; } // Consider a more specific type if needed
        public string? Description { get; set; }
        public decimal? Rating { get; set; }
        public int? StarRating { get; set; }
        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan CheckOutTime { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public bool IsActive { get; set; }
    }
}