csharp
using MediatR;
using System.Collections.Generic;

namespace HotelBookingSystem.Application.Features.Facilities.Queries
{
    public class GetAllFacilitiesQuery : IRequest<IEnumerable<FacilityDto>>
    {
        // No properties needed for getting all facilities
    }
}