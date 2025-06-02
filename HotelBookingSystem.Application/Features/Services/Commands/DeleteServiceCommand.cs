csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Services.Commands
{
    public class DeleteServiceCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}