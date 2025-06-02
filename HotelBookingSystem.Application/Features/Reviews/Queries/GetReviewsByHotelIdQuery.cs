csharp
using MediatR;
using System.Collections.Generic;

namespace HotelBookingSystem.Application.Features.Reviews.Queries
{
    public class GetReviewsByHotelIdQuery : IRequest<IEnumerable<ReviewDto>>
    {
        public long HotelId { get; set; }
    }
}