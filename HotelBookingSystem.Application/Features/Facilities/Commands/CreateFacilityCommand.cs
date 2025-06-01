csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Facilities.Commands
{
    public class CreateFacilityCommand : IRequest<long>
    {
        public long HotelId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Category { get; set; }
        public bool IsChargeable { get; set; }
        public string? OperatingHours { get; set; } // Consider a more specific type for JSONB
        public bool IsActive { get; set; } = true;
    }
}