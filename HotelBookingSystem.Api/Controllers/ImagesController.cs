csharp
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
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

            var images = await _imageRepository.GetByEntityAsync(entityType, entityId);

            return Ok(images);
        }
    }
}