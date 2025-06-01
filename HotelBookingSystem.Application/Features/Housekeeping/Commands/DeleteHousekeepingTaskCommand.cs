csharp
using MediatR;

namespace HotelBookingSystem.Application.Features.Housekeeping.Commands
{
    public class DeleteHousekeepingTaskCommand : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}