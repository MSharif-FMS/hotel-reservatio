csharp
using HotelBookingSystem.Application.Features.Housekeeping.Queries;
using HotelBookingSystem.Application.Interfaces;
using MediatR;

namespace HotelBookingSystem.Application.Features.Housekeeping.Handlers
{
    public class GetHousekeepingTasksByStaffIdQueryHandler : IRequestHandler<GetHousekeepingTasksByStaffIdQuery, IEnumerable<HousekeepingDto>>
    {
        private readonly IHousekeepingRepository _housekeepingRepository;

        public GetHousekeepingTasksByStaffIdQueryHandler(IHousekeepingRepository housekeepingRepository)
        {
            _housekeepingRepository = housekeepingRepository;
        }

        public async Task<IEnumerable<HousekeepingDto>> Handle(GetHousekeepingTasksByStaffIdQuery request, CancellationToken cancellationToken)
        {
            var housekeepingTasks = await _housekeepingRepository.GetHousekeepingTasksByStaffIdAsync(request.StaffId);

            // Map the entities to DTOs (Assuming you have a mapping profile or manual mapping)
            var housekeepingDtos = housekeepingTasks.Select(task => new HousekeepingDto
            {
                Id = task.Id,
                RoomId = task.RoomId,
                StaffId = task.StaffId,
                TaskType = task.TaskType,
                Status = task.Status,
                ScheduledTime = task.ScheduledTime,
                CompletedTime = task.CompletedTime,
                Notes = task.Notes,
                CreatedAt = task.CreatedAt,
                UpdatedAt = task.UpdatedAt
            });

            return housekeepingDtos;
        }
    }
}