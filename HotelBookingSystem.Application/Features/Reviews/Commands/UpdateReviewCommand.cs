csharp
using MediatR;
using System;

namespace HotelBookingSystem.Application.Features.Reviews.Commands.UpdateReview
{
    public class UpdateReviewCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public int? Rating { get; set; }
        public int? Cleanliness { get; set; }
        public int? Comfort { get; set; }
        public int? Location { get; set; }
        public int? Service { get; set; }
        public string? Comment { get; set; } // Make comment optional
        public bool? IsApproved { get; set; } // Assuming IsApproved is a field that can be updated
    }
    }
}