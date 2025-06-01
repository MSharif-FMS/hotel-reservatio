csharp
using MediatR;
using System;

namespace HotelBookingSystem.Application.Features.Housekeeping.Commands
{
    public class CreateHousekeepingTaskCommand : IRequest<long>
    {
        public long RoomId { get; set; }
        public long StaffId { get; set; }
        public string TaskType { get; set; }
        public DateTimeOffset ScheduledTime { get; set; }
        public string? Notes { get; set; }
    }
}