csharp
using MediatR;
using System;

namespace HotelBookingSystem.Application.Features.Reviews.Commands.CreateReview
{
    public class CreateReviewCommand : IRequest<long>
    {
        public long HotelId { get; set; }
        public long? UserId { get; set; }
        public long? ReservationId { get; set; }
        public int Rating { get; set; }
        public int? Cleanliness { get; set; }
        public int? Comfort { get; set; }
        public int? Location { get; set; }
        public int? Service { get; set; }
        public string? Comment { get; set; }
    }
}