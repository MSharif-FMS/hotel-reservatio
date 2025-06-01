csharp
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelBookingSystem.Application.Services; // Assuming this path for your service

namespace HotelBookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService; // Assuming an interface for your payment service

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        /// <summary>
        /// Creates a new payment.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentRequest request) // Replace CreatePaymentRequest with your actual DTO for payment creation
        {
            if (request == null)
            {
                return BadRequest();
            }

            try
            {
                // Assuming your service method takes a request DTO and returns a response DTO or similar
                var paymentResult = await _paymentService.ProcessPaymentAsync(request); // Replace ProcessPaymentAsync and request with your service method and DTO

                if (paymentResult != null && paymentResult.IsSuccessful) // Assuming a property to indicate success
                {
                    return Ok(paymentResult); // Return the result of the payment processing
                }
                else
                {
                    // Return a more specific error if possible based on paymentResult
                    return BadRequest(paymentResult?.ErrorMessage ?? "Payment processing failed.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(500, "An error occurred while processing the payment.");
            }
        }

        /// <summary>
        /// Gets all payments for a specific reservation.
        /// </summary>
        [HttpGet("reservation/{reservationId}")]
        public async Task<IActionResult> GetPaymentsByReservation(long reservationId)
        {
            try
            {
                var payments = await _paymentService.GetPaymentsByReservationIdAsync(reservationId); // Replace with your service method

                if (payments == null || !payments.Any())
                {
                    return NotFound($"No payments found for reservation with ID {reservationId}.");
                }

                return Ok(payments);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(500, $"An error occurred while retrieving payments for reservation {reservationId}.");
            }
        }

        /// <summary>
        /// Gets a single payment by ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentById(long id)
        {
            try
            {
                var payment = await _paymentService.GetPaymentByIdAsync(id); // Replace with your service method

                if (payment == null)
                {
                    return NotFound($"Payment with ID {id} not found.");
                }

                return Ok(payment);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(500, $"An error occurred while retrieving payment with ID {id}.");
            }
        }
    }

    // Placeholder for your payment creation request DTO
    public class CreatePaymentRequest
    {
        public long ReservationId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string PaymentMethod { get; set; }
        // Add other necessary payment details
    }

    // Placeholder for your payment processing result DTO
    public class PaymentResult
    {
        public bool IsSuccessful { get; set; }
        public string TransactionId { get; set; }
        public string ErrorMessage { get; set; }
        // Add other relevant payment result details
    }
}