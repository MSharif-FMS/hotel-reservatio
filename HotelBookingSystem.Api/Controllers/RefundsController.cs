csharp
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelBookingSystem.Application.Interfaces;
using HotelBookingSystem.Application.DTOs.Refunds;

namespace HotelBookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RefundsController : ControllerBase
    {
        private readonly IRefundService _refundService;

        public RefundsController(IRefundService refundService)
        {
            _refundService = refundService;
        }

        /// <summary>
        /// Creates a new refund.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateRefund([FromBody] CreateRefundDto createRefundDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var refundDto = await _refundService.CreateRefundAsync(createRefundDto);
                return Created