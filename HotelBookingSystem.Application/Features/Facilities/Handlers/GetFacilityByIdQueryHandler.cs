csharp
using MediatR;
using HotelBookingSystem.Application.Features.Facilities.Queries;
using HotelBookingSystem.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Facilities.Handlers
{
    public class GetFacilityByIdQueryHandler : IRequestHandler<GetFacilityByIdQuery, FacilityDto>
    {
        private readonly IFacilityRepository _facilityRepository;

        public GetFacilityByIdQueryHandler(IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        public async Task<FacilityDto> Handle(GetFacilityByIdQuery request, CancellationToken cancellationToken)
        {
            var facility = await _facilityRepository.GetByIdAsync(request.Id);

            if (facility == null)
            {
                return null; // Or throw a custom not found exception
            }

            // Map the Facility entity to FacilityDto
            var facilityDto = new FacilityDto
            {
                Id = facility.Id,
                HotelId = facility.HotelId,
                Name = facility.Name,
                Description = facility.Description,
                Category = facility.Category,
                IsChargeable = facility.IsChargeable,
                OperatingHours = facility.OperatingHours, // Assuming OperatingHours is directly mappable or needs conversion
                IsActive = facility.IsActive,
                CreatedAt = facility.CreatedAt,
                UpdatedAt = facility.UpdatedAt
            };

            return facilityDto;
        }
    }
}