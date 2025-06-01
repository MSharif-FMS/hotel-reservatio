csharp
using MediatR;
using System;
namespace HotelBookingSystem.Application.Features.Hotels.Commands
{
    public class CreateHotelCommand : IRequest<long>
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Address { get; set; } // Consider a specific type later
        public string Description { get; set; }
        public decimal? Rating { get; set; }
        public int? StarRating { get; set; }
        public TimeSpan CheckInTime { get; set; } = TimeSpan.FromHours(15);
        public TimeSpan CheckOutTime { get; set; } = TimeSpan.FromHours(11);
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; } 
        public bool IsActive { get; set; } = true;
    }
}