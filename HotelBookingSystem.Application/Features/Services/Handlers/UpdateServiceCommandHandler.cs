csharp
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.Features.Services.Handlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, bool>
    {
        private readonly IServiceRepository _serviceRepository;

        public UpdateServiceCommandHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<bool> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.GetByIdAsync(request.Id);

            if (service == null)
            {
                return false; // Service not found
            }

            service.Name = request.Name;
            service.Description = request.Description;
            service.Price = request.Price;
            service.Category = request.Category;
            service.IsActive = request.IsActive;
            // Assuming UpdatedAt is handled by EF Core or in a base entity

            await _serviceRepository.UpdateAsync(service);

            return true;
        }
    }
}