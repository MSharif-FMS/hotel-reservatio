csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Facilities.Queries
{
    public class GetFacilityByIdQuery : IRequest<FacilityDto>
    {
        public long FacilityId { get; set; }
    }
}