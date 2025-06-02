csharp
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelBookingSystem.Application.Interfaces;
using MediatR;
using HotelBookingSystem.Application.Features.Refunds.Commands.CreateRefundCommand;
using HotelBookingSystem.Application.Features.Refunds.Queries.GetRefundByIdQuery;
using HotelBookingSystem.Application.DTOs.Refunds;

namespace HotelBookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RefundsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RefundsController(IMediator mediator)
        {
            _mediator = mediator;
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
                var command = new CreateRefundCommand
                {
                    PaymentId = createRefundDto.PaymentId,
                    Amount = createRefundDto.Amount,
                    Reason = createRefundDto.Reason
                };
                var refundDto = await _mediator.Send(command);
                return CreatedAtAction(nameof(GetRefundById), new { id = refundDto.Id }, refundDto);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while creating the refund.");
            }
        }

        /// <summary>
        /// Gets a refund by its ID.
        /// </summary>
        /// <param name="id">The ID of the refund.</param>
        /// <returns>The refund with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<RefundDto>> GetRefundById(long id)
        {
            var query = new GetRefundByIdQuery { Id = id };
            var refundDto = await _mediator.Send(query);

            if (refundDto == null)
            {
                return NotFound();
            }
            return Ok(refundDto);
        }

        /// <summary>
        /// Gets all refunds for a specific payment.
        /// </summary>
        /// <param name="paymentId">The ID of the payment.</param>
        /// <returns>A list of refunds.</returns>
        [HttpGet("payment/{paymentId}")]
        public async Task<ActionResult<IEnumerable<RefundDto>>> GetRefundsByPaymentId(long paymentId)
        {
            var query = new Application.Features.Refunds.Queries.GetRefundsByPaymentIdQuery { PaymentId = paymentId };
            var refunds = await _mediator.Send(query);
            return Ok(refunds);
        }

        /// <summary>
        /// Updates an existing refund.
        /// </summary>
        /// <param name="id">The ID of the refund to update.</param>
        /// <param name="command">The refund update command.</param>
        /// <returns>No content if successful.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRefund(long id, [FromBody] UpdateRefundCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Refund ID in the URL and body do not match.");
            }
            var success = await _mediator.Send(command);
            if (!success)
            {
                return NotFound($"Refund with ID {id} not found or update failed.");
            }
            return NoContent();
        }
    }
}