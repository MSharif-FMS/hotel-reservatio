csharp
using HotelBookingSystem.Application.Features.Housekeeping.Commands;
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem.Application.Features.Housekeeping.Handlers
{
    public class CreateHousekeepingTaskCommandHandler : IRequestHandler<CreateHousekeepingTaskCommand, long>
    {
        private readonly IHousekeepingRepository _housekeepingRepository;

        public CreateHousekeepingTaskCommandHandler(IHousekeepingRepository housekeepingRepository)
        {
            _housekeepingRepository = housekeepingRepository;
        }

        public async Task<long> Handle(CreateHousekeepingTaskCommand request, CancellationToken cancellationToken)
        {
            var housekeepingTask = new Housekeeping
            {
                RoomId = request.RoomId,
                StaffId = request.StaffId,
                TaskType = request.TaskType,
                Status = request.Status,
                ScheduledTime = request.ScheduledTime,
                CompletedTime = request.CompletedTime,
                Notes = request.Notes,
                CreatedAt = System.DateTimeOffset.UtcNow,
                UpdatedAt = System.DateTimeOffset.UtcNow
            };

            await _housekeepingRepository.AddAsync(housekeepingTask);

            return housekeepingTask.Id;
        }
    }
}