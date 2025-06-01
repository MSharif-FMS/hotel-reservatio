csharp
using MediatR;
using System.Collections.Generic;

namespace HotelBookingSystem.Application.Features.Housekeeping.Queries
{
    public class GetHousekeepingTasksByStaffIdQuery : IRequest<IEnumerable<HousekeepingDto>>
    {
        public long StaffId { get; set; }
    }
}