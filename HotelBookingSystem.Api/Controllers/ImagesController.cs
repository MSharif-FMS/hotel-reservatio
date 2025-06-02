csharp
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using HotelBookingSystem.Application.Features.Images.Queries;
using HotelBookingSystem.Application.Features.Images.Commands;


namespace HotelBookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ImagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> GetImageById(long id)
        {
            var image = await _imageRepository.GetByIdAsync(id);

            if (image == null)
            {
                return NotFound();
            }

            return Ok(image);
        }

        [HttpGet("entity/{entityType}/{entityId}")]
        public async Task<ActionResult<IEnumerable<Image>>> GetImagesForEntity(string entityType, long entityId)
        {
            // Basic validation for entityType
            if (entityType?.ToLower() is not ("hotel" or "room_type" or "facility" or "service"))
            {
                return BadRequest("Invalid entity type specified.");
            }

            var query = new GetImagesByEntityQuery { EntityType = entityType, EntityId = entityId };
            var images = await _mediator.Send(query);

            return Ok(images);
        }

        [HttpPost]
        public async Task<ActionResult<ImageDto>> CreateImage([FromBody] CreateImageCommand command)
        {
            var imageId = await _mediator.Send(command);
            // Assuming CreateImageCommand handler returns the created ImageDto
            var createdImage = await _mediator.Send(new GetImageByIdQuery { Id = imageId }); 
            return CreatedAtAction(nameof(GetImageById), new { id = imageId }, createdImage);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateImage(long id, [FromBody] UpdateImageCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Image ID in the URL and body do not match.");
            }
            var success = await _mediator.Send(command);
            if (!success)
            {
                return NotFound($"Image with ID {id} not found.");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteImage(long id)
        {
            var success = await _mediator.Send(new DeleteImageCommand { Id = id });
            if (!success) return NotFound();
            return NoContent();
        }
    }
}