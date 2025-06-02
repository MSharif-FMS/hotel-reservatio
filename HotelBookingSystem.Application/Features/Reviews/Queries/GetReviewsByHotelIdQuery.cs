csharp
using MediatR;
using System.Collections.Generic;
using HotelBookingSystem.Application.Features.Reviews.Queries;

namespace HotelBookingSystem.Application.Features.Reviews.Queries.GetReviewsByHotelId
{
    public class GetReviewsByHotelIdQuery : IRequest<IEnumerable<ReviewDto>>
    {
        public long HotelId { get; set; }
    }
}