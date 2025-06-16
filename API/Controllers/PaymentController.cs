using Application.DTOs.Payment;
using Application.IServices;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentsByBookingId(int id)
        {
            var payment =await _paymentService.GetPaymentsByBookingId(id);
            return payment != null ? Ok(payment) : NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            return Ok(await _paymentService.GetAllPayments());
        }
        [HttpPost]
        public async Task<IActionResult> AddPayment([FromBody] RequestPaymentDTO dto)
        {
            var createdDto = await _paymentService.AddPayment(dto);
            return CreatedAtAction(nameof(GetPaymentsByBookingId), new { id = createdDto.Id }, createdDto);
        }
    }
}
