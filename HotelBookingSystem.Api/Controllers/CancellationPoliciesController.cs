csharp
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelBookingSystem.Application.Interfaces;
using MediatR;
using HotelBookingSystem.Application.Features.CancellationPolicies.Queries.GetAllCancellationPolicies;
using HotelBookingSystem.Application.Features.CancellationPolicies.Queries.GetCancellationPolicyById;
using HotelBookingSystem.Application.Features.CancellationPolicies.Commands.CreateCancellationPolicy;
using HotelBookingSystem.Application.Features.CancellationPolicies.Commands.UpdateCancellationPolicy;
using HotelBookingSystem.Application.Features.CancellationPolicies.Commands.DeleteCancellationPolicy;
using HotelBookingSystem.Application.DTOs.CancellationPolicy;

namespace HotelBookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CancellationPoliciesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CancellationPoliciesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CancellationPolicyDto>>> GetCancellationPolicies()
        {
            var policies = await _mediator.Send(new GetAllCancellationPoliciesQuery());
            return Ok(policies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CancellationPolicyDto>> GetCancellationPolicy(long id)
        {
            var policy = await _mediator.Send(new GetCancellationPolicyByIdQuery { Id = id });

            if (policy == null)
            {
                return NotFound();
            }

            return Ok(policy);
        }

        [HttpPost]
        public async Task<ActionResult<CancellationPolicyDto>> CreateCancellationPolicy([FromBody] CreateCancellationPolicyCommand command)
        {
            var policy = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCancellationPolicy), new { id = policy.Id }, policy);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CancellationPolicyDto>> UpdateCancellationPolicy(long id, [FromBody] UpdateCancellationPolicyCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Cancellation Policy ID in the URL and body do not match.");
            }

            var policy = await _mediator.Send(command);
            if (policy == null)
            {
                return NotFound($"Cancellation Policy with ID {id} not found.");
            }
            return Ok(policy);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> DeleteCancellationPolicy(long id)
        {
            var result = await _mediator.Send(new DeleteCancellationPolicyCommand { Id = id });

            // Assuming the command handler returns Unit on success and throws NotFoundException on failure
            return NoContent();
        }
    }
}

            return Ok(policy);
        }
    }
}