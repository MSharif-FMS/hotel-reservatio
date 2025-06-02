csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Images.Commands
{
    public class DeleteImageCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}