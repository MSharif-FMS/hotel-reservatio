csharp
using HotelBookingSystem.Application.Features.Facilities.Commands;
using HotelBookingSystem.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Facilities.Handlers
{
    public class DeleteFacilityCommandHandler : IRequestHandler<DeleteFacilityCommand, Unit>
    {
        private readonly IFacilityRepository _facilityRepository;

        public DeleteFacilityCommandHandler(IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        public async Task<Unit> Handle(DeleteFacilityCommand request, CancellationToken cancellationToken)
        {
            await _facilityRepository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}