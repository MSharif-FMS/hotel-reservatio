csharp
using MediatR;
using System.Collections.Generic;

namespace HotelBookingSystem.Application.Features.RatePlans.Queries
{
    // Assuming RatePlanDto exists
    public class GetRatePlansByHotelIdQuery : IRequest<IEnumerable<RatePlanDto>>
    {
        public long HotelId { get; set; }

        public GetRatePlansByHotelIdQuery(long hotelId)
        {
            HotelId = hotelId;
        }
    }
}