csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Services.Commands.CreateService
{
    public class CreateServiceCommand : IRequest<long>
    {
        public long HotelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public bool IsActive { get; set; } = true;
    }
}