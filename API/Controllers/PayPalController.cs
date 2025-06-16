using Application.IServices;
using Application.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities.AppEntities;
using Application.DTOs.Payment;
using AutoMapper;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PayPalController : ControllerBase
    {
        private readonly IPayPalService _payPalService;
        private readonly IPaymentService _paymentService;

        public PayPalController(
            IPayPalService payPalService,
            IPaymentService paymentService)
        {
            _payPalService = payPalService;
            _paymentService = paymentService;
        }

        [HttpPost("create-order/{bookingId:int}")]
        public async Task<IActionResult> CreateOrder(int bookingId)
        {
            try
            {
                var payments = await _paymentService.GetPaymentsByBookingId(bookingId);
                var payment = payments.FirstOrDefault();

                if (payment == null || payment.AmountDue <= 0)
                {
                    return BadRequest("Valid payment record for the booking not found or amount is zero.");
                }

                var order = await _payPalService.CreateOrderAsync(payment.AmountDue, "USD");
                return Ok(new { orderId = order.Id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating PayPal order: {ex.Message}");
            }
        }

        [HttpPost("capture-order/{orderId}")]
        public async Task<IActionResult> CaptureOrder(string orderId)
        {
            try
            {
                var capturedOrder = await _payPalService.CaptureOrderAsync(orderId);
                var captureId = capturedOrder.PurchaseUnits[0].Payments.Captures[0].Id;

                // Here, you would save the captureId to your database.

                return Ok(new { captureId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error capturing PayPal order: {ex.Message}");
            }
        }
    }
}