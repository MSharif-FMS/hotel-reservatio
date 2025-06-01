csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Housekeeping.Commands
{
    public class UpdateHousekeepingTaskStatusCommand : IRequest<Unit>
    {
        public long Id { get; set; }
        public string Status { get; set; }
    }
}