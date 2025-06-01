csharp
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelBookingSystem.Application.Features.Housekeeping.Commands.CreateHousekeepingTask;
using HotelBookingSystem.Application.Features.Housekeeping.Commands.UpdateHousekeepingTask;
using HotelBookingSystem.Application.Features.Housekeeping.Queries.GetHousekeepingTaskById;
using HotelBookingSystem.Application.Features.Housekeeping.Queries.GetHousekeepingTasksByRoom;
using HotelBookingSystem.Application.Features.Housekeeping.Queries.GetHousekeepingTasksByStaff;
using MediatR;

namespace HotelBookingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousekeepingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HousekeepingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHousekeepingTask([FromBody] CreateHousekeepingTaskCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetHousekeepingTaskById), new { id = result }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHousekeepingTaskById(long id)
        {
            var query = new GetHousekeepingTaskByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("room/{roomId}")]
        public async Task<IActionResult> GetHousekeepingTasksByRoom(long roomId)
        {
            var query = new GetHousekeepingTasksByRoomQuery { RoomId = roomId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("staff/{staffId}")]
        public async Task<IActionResult> GetHousekeepingTasksByStaff(long staffId)
        {
            var query = new GetHousekeepingTasksByStaffQuery { StaffId = staffId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateHousekeepingTaskStatus(long id, [FromBody] UpdateHousekeepingTaskStatusCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Mismatch between route ID and request body ID.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // Add other update endpoints as needed (e.g., update assigned staff, scheduled time)
         [HttpPut("{id}")]
         public async Task<IActionResult> UpdateHousekeepingTask(long id, [FromBody] UpdateHousekeepingTaskCommand command)
         {
             if (id != command.Id)
             {
                 return BadRequest("Mismatch between route ID and request body ID.");
             }

             if (!ModelState.IsValid)
             {
                 return BadRequest(ModelState);
             }

             var result = await _mediator.Send(command);

             if (!result)
             {
                 return NotFound();
             }

             return NoContent();
         }
    }
}