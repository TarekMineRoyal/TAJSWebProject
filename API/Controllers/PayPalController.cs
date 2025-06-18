using Application.IServices;
using Application.IRepositories;
using Domain.Entities.AppEntities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PayPalController : ControllerBase
    {
        private readonly IPayPalService _payPalService;
        private readonly IPaymentService _paymentService;
        private readonly IGenericRepository<PaymentTransaction> _paymentTransactionRepository;
        private readonly IGenericRepository<PaymentMethod> _paymentMethodRepository;

        public PayPalController(
            IPayPalService payPalService,
            IPaymentService paymentService,
            IGenericRepository<PaymentTransaction> paymentTransactionRepository,
            IGenericRepository<PaymentMethod> paymentMethodRepository)
        {
            _payPalService = payPalService;
            _paymentService = paymentService;
            _paymentTransactionRepository = paymentTransactionRepository;
            _paymentMethodRepository = paymentMethodRepository;
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

                var payPalMethod = await _paymentMethodRepository.GetFirstOrDefaultAsync(pm => pm.Method == "PayPal");
                if (payPalMethod == null)
                {
                    return StatusCode(500, "PayPal payment method not found in the database.");
                }

                var transaction = new PaymentTransaction
                {
                    PaymentId = payment.Id,
                    Amount = payment.AmountDue,
                    TransactionType = TType.Deposit,
                    TransactionDate = DateTime.UtcNow,
                    PaymentMethodId = payPalMethod.Id,
                    PayPalOrderId = order.Id
                };

                await _paymentTransactionRepository.AddAsync(transaction);
                await _paymentTransactionRepository.SaveChangesAsync();

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
                return Ok(new { captureId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error capturing PayPal order: {ex.Message}");
            }
        }
    }
}
