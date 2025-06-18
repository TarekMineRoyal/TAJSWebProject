using Application.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentTransactionController : Controller
    {
        private readonly IPaymentTransactionService _paymentTransactionService;

        public PaymentTransactionController(IPaymentTransactionService paymentTransactionService)
        {
            _paymentTransactionService = paymentTransactionService;
        }

        [HttpPost("paypal/create-order/{bookingId:int}")]
        public async Task<IActionResult> CreatePayPalOrder(int bookingId)
        {
            try
            {
                var orderId = await _paymentTransactionService.CreatePayPalOrderAsync(bookingId);
                return Ok(new { orderId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating PayPal order: {ex.Message}");
            }
        }

        [HttpPost("paypal/capture-order/{orderId}")]
        public async Task<IActionResult> CapturePayPalOrder(string orderId)
        {
            try
            {
                var capturedOrder = await _paymentTransactionService.CapturePayPalOrderAsync(orderId);
                return Ok(capturedOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
