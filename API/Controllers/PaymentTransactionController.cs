using Application.DTOs.Payment;
using Application.IServices;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentTransactionController : Controller
    {
        private readonly IPaymentTransactionService _paymentTransactionService;
        private readonly IPayPalService _payPalService; // Make sure to inject IPayPalService

        public PaymentTransactionController(
            IPaymentTransactionService paymentTransactionService,
            IPayPalService payPalService) // Add IPayPalService here
        {
            _paymentTransactionService = paymentTransactionService;
            _payPalService = payPalService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionById(int id)
        {
            var transaction = await _paymentTransactionService.GetPaymentTransactionById(id);
            return transaction != null ? Ok(transaction) : NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            return Ok(await _paymentTransactionService.GetAllPaymentTransactions());
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] RequestPaymentTransactionDTO dto)
        {
            var createdDto = await _paymentTransactionService.AddPaymentTransaction(dto);
            // This response should return the PayPalOrderId to the frontend
            return Ok(createdDto);
        }

        // --- Add this new endpoint ---
        [HttpPost("{orderId}/capture")]
        public async Task<IActionResult> CapturePayPalOrder(string orderId)
        {
            try
            {
                // Call the service to capture the payment
                var capturedOrder = await _payPalService.CaptureOrderAsync(orderId);

                // Here you would typically update your database record to mark
                // the transaction as complete and store the capture ID.
                // For example:
                // await _paymentTransactionService.MarkTransactionAsComplete(orderId, capturedOrder.Id);

                return Ok(capturedOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
