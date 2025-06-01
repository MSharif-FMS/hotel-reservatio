csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Hotels.Commands
{
    public class DeleteHotelCommand : IRequest<bool>
 {
        public long HotelId { get; set; }
    }
}