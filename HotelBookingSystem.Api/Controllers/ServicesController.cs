csharp
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Domain.Entities;

namespace HotelBookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository; // Assuming IServiceRepository exists

        public ServicesController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
            var services = await _serviceRepository.GetAllAsync();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(int id)
        {
            var service = await _serviceRepository.GetByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }

        [HttpGet("hotel/{hotelId}")]
        public async Task<ActionResult<IEnumerable<Service>>> GetServicesByHotel(int hotelId)
        {
            var services = await _serviceRepository.GetByHotelIdAsync(hotelId); // Assuming this method exists
            return Ok(services);
        }

        // Add other CRUD endpoints (POST, PUT, DELETE) as needed
    }
}