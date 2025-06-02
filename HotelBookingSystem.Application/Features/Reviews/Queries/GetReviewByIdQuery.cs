csharp
using MediatR;
using HotelBookingSystem.Application.Features.Reviews.Queries; // Assuming ReviewDto is in this namespace

namespace HotelBookingSystem.Application.Features.Reviews.Queries
{
    public class GetReviewByIdQuery : IRequest<ReviewDto>
    {
        public long Id { get; set; }
    }
}