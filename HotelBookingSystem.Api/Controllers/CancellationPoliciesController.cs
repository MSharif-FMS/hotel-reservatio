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
    public class CancellationPoliciesController : ControllerBase
    {
        private readonly ICancellationPolicyRepository _cancellationPolicyRepository;

        public CancellationPoliciesController(ICancellationPolicyRepository cancellationPolicyRepository)
        {
            _cancellationPolicyRepository = cancellationPolicyRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CancellationPolicy>>> GetCancellationPolicies()
        {
            var policies = await _cancellationPolicyRepository.GetAllAsync();
            return Ok(policies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CancellationPolicy>> GetCancellationPolicy(long id)
        {
            var policy = await _cancellationPolicyRepository.GetByIdAsync(id);

            if (policy == null)
            {
                return NotFound();
            }

            return Ok(policy);
        }
    }
}