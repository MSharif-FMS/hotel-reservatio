csharp
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using HotelBookingSystem.Application.Features.Services.Commands.CreateService;
using HotelBookingSystem.Application.Features.Services.Commands.DeleteService;
using HotelBookingSystem.Application.Features.Services.Commands.UpdateService;
using HotelBookingSystem.Application.Features.Services.Queries.GetAllServices;
using HotelBookingSystem.Application.Features.Services.Queries.GetServiceById;
using HotelBookingSystem.Application.Features.Services.Queries.GetServicesByHotelId;
using HotelBookingSystem.Application.Features.Services.Queries; // Assuming ServiceDto is here

namespace HotelBookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceDto>>> GetServices()
        {
            var services = await _mediator.Send(new GetAllServicesQuery());
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceDto>> GetService(int id)
        {
            var service = await _mediator.Send(new GetServiceByIdQuery { Id = id });
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }
        
        [HttpPost]
        public async Task<ActionResult<long>> CreateService([FromBody] CreateServiceCommand command)
        {
            var serviceId = await _mediator.Send(command);
            // Assuming the command handler returns the ID of the newly created service
            return CreatedAtAction(nameof(GetService), new { id = serviceId }, serviceId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateService(int id, [FromBody] UpdateServiceCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Service ID in the URL and body do not match.");
            }
            var success = await _mediator.Send(command);
            if (!success)
            {
                return NotFound($"Service with ID {id} not found.");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteService(int id)
        {
            var success = await _mediator.Send(new DeleteServiceCommand { Id = id });
            if (!success)
            {
                return NotFound($"Service with ID {id} not found.");
            }
            return NoContent();
        }

        [HttpGet("hotel/{hotelId}")]
        public async Task<ActionResult<IEnumerable<ServiceDto>>> GetServicesByHotel(int hotelId)
        {
            var services = await _mediator.Send(new GetServicesByHotelIdQuery { HotelId = hotelId });
            return Ok(services);
        }
    }
}