csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Facilities.Commands
{
    public class DeleteFacilityCommand : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}