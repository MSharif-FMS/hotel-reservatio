csharp
using MediatR;
using System;

namespace HotelBookingSystem.Application.Features.Housekeeping.Commands
{
    public class UpdateHousekeepingTaskCommand : IRequest<Unit>
    {
        public long Id { get; set; }
        public long RoomId { get; set; }
        public long StaffId { get; set; }
        public string TaskType { get; set; }
        public string Status { get; set; }
        public DateTimeOffset ScheduledTime { get; set; }
        public DateTimeOffset? CompletedTime { get; set; }
        public string Notes { get; set; }
    }
}