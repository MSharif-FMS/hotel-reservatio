csharp
using HotelBookingSystem.Application.Features.Facilities.Commands;
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Facilities.Handlers
{
    public class CreateFacilityCommandHandler : IRequestHandler<CreateFacilityCommand, long>
    {
        private readonly IFacilityRepository _facilityRepository;

        public CreateFacilityCommandHandler(IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        public async Task<long> Handle(CreateFacilityCommand request, CancellationToken cancellationToken)
        {
            var facility = new Facility
            {
                HotelId = request.HotelId,
                Name = request.Name,
                Description = request.Description,
                Category = request.Category,
                IsChargeable = request.IsChargeable,
                OperatingHours = request.OperatingHours, // Assuming OperatingHours is handled appropriately
                IsActive = request.IsActive,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow
            };

            await _facilityRepository.AddAsync(facility);

            return facility.Id;
        }
    }
}