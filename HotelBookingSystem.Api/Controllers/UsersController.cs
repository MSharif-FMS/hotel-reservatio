csharp
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using HotelBookingSystem.Application.Features.Users.Commands.CreateUser;
using HotelBookingSystem.Application.Features.Users.Commands.UpdateUser;
using HotelBookingSystem.Application.Features.Users.Commands.DeleteUser;
using HotelBookingSystem.Application.Features.Users.Queries.GetAllUsers;
using HotelBookingSystem.Application.Features.Users.Queries.GetUserById;
using HotelBookingSystem.Application.DTOs.User; // Assuming your DTOs are here

namespace HotelBookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var query = new GetAllUsersQuery();
            var users = await _mediator.Send(query);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(long id)
        {
            var query = new GetUserByIdQuery { Id = id };
            var user = await _mediator.Send(query);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<long>> CreateUser([FromBody] CreateUserCommand command)
        {
            var userId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetUser), new { id = userId }, userId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(long id, [FromBody] UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("ID in URL and body do not match.");
            }

            var success = await _mediator.Send(command);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var success = await _mediator.Send(new DeleteUserCommand { Id = id });

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}