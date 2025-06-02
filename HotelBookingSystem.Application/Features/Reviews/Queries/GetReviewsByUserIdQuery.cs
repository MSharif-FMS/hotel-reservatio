csharp
using MediatR;
using System.Collections.Generic;
using HotelBookingSystem.Application.Features.Reviews.Queries; // Adjust namespace based on where ReviewDto is

namespace HotelBookingSystem.Application.Features.Reviews.Queries.GetReviewsByUser
{
    public class GetReviewsByUserIdQuery : IRequest<IEnumerable<ReviewDto>>
    {
        public long UserId { get; set; }
    }
}