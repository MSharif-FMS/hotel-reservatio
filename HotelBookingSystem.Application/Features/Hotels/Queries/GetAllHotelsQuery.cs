using MediatR;
using System.Collections.Generic;

namespace HotelBookingSystem.Application.Features.Hotels.Queries
{
    
    public class GetAllHotelsQuery : IRequest<IEnumerable<HotelDto>>
    {
        // No properties needed for this query
    }
}