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
        private readonly IGenericRepository<PaymentTransaction> _paymentTransactionRepo;
        private readonly IGenericRepository<PaymentMethod> _paymentMethodRepo;
        private readonly IMapper _mapper;


        public PayPalController(
            IPayPalService payPalService,
            IPaymentService paymentService,
            IGenericRepository<PaymentTransaction> paymentTransactionRepo,
            IGenericRepository<PaymentMethod> paymentMethodRepo,
            IMapper mapper)
        {
            _payPalService = payPalService;
            _paymentService = paymentService;
            _paymentTransactionRepo = paymentTransactionRepo;
            _paymentMethodRepo = paymentMethodRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a PayPal order and returns the Order ID to the frontend.
        /// </summary>
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

                string orderId = await _payPalService.CreateOrderAsync(payment.AmountDue, "USD");
                return Ok(new { orderId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating PayPal order: {ex.Message}");
            }
        }

        /// <summary>
        /// Captures the payment after the user approves it on the frontend.
        /// </summary>
        [HttpPost("capture-order/{orderId}")]
        public async Task<IActionResult> CaptureOrder(string orderId)
        {
            try
            {
                string captureId = await _payPalService.CaptureOrderAsync(orderId);

                // You might want to find the booking/payment associated with this order
                // and save the captureId and update the status.
                // For simplicity, we'll just return success here.
                // In a real app, you would add the transaction details to your database here.

                return Ok(new { captureId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error capturing PayPal order: {ex.Message}");
            }
        }
    }
}