csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Reviews.Queries.GetReviewById
{
    public class GetReviewByIdQuery : IRequest<ReviewDto>
    {
        public long Id { get; set; }
    }
}