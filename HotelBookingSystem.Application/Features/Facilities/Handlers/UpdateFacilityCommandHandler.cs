csharp
using HotelBookingSystem.Application.Features.Facilities.Commands;
using HotelBookingSystem.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Facilities.Handlers
{
    public class UpdateFacilityCommandHandler : IRequestHandler<UpdateFacilityCommand, Unit>
    {
        private readonly IFacilityRepository _facilityRepository;

        public UpdateFacilityCommandHandler(IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        public async Task<Unit> Handle(UpdateFacilityCommand request, CancellationToken cancellationToken)
        {
            var facility = await _facilityRepository.GetByIdAsync(request.Id);

            if (facility == null)
            {
                // Handle not found, maybe throw a custom exception
                return Unit.Value;
            }

            facility.Name = request.Name;
            facility.Description = request.Description;
            facility.Category = request.Category;
            facility.IsChargeable = request.IsChargeable;
            facility.OperatingHours = request.OperatingHours; // Assuming OperatingHours is a string or compatible type
            facility.IsActive = request.IsActive;
            facility.UpdatedAt = System.DateTimeOffset.UtcNow;

            await _facilityRepository.UpdateAsync(facility);

            return Unit.Value;
        }
    }
}