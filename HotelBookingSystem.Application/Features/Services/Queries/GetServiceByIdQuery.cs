csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Services.Queries.GetServiceById
{
    public class GetServiceByIdQuery : IRequest<ServiceDto> // Assuming ServiceDto exists
    {
        public long Id { get; set; }
    }
}