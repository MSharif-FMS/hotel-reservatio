csharp
using MediatR;
using System.Collections.Generic;

namespace HotelBookingSystem.Application.Features.Facilities.Queries
{
    public class GetFacilitiesByHotelIdQuery : IRequest<IEnumerable<FacilityDto>>
    {
        public long HotelId { get; set; }

        public GetFacilitiesByHotelIdQuery(long hotelId)
        {
            HotelId = hotelId;
        }
    }
}