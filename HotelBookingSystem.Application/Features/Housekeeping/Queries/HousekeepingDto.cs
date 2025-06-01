csharp
namespace HotelBookingSystem.Application.Features.Housekeeping.Queries
{
    public class HousekeepingDto
    {
        public long Id { get; set; }
        public long RoomId { get; set; }
        public long StaffId { get; set; }
        public string TaskType { get; set; }
        public string Status { get; set; }
        public DateTimeOffset ScheduledTime { get; set; }
        public DateTimeOffset? CompletedTime { get; set; }
        public string Notes { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}