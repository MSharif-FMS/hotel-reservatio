csharp
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HotelBookingSystem.Application.Features.Services.Commands;
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Application.Features.Services.Handlers
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, long>
    {
        private readonly IServiceRepository _serviceRepository;

        public CreateServiceCommandHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<long> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = new Service
            {
                HotelId = request.HotelId,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Category = request.Category,
                IsActive = request.IsActive,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow
            };

            await _serviceRepository.AddAsync(service);

            // Optionally, you might want to save changes here or rely on a Unit of Work pattern
            // await _serviceRepository.SaveChangesAsync(); 

            return service.Id;
        }
    }
}