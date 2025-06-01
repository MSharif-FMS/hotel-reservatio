csharp
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
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
    }
}