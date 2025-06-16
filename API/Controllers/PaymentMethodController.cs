using Application.DTOs.CarBooking;
using Application.DTOs.Payment;
using Application.IServices;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentMethodController : Controller
    {
        private readonly IPaymentMethodService _paymentMethodService;
        public PaymentMethodController(IPaymentMethodService paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentMethodById(int id)
        {
            var method = await _paymentMethodService.GetPaymentMethodByIdAsync(id);
            return method != null ? Ok(method) : NotFound();
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllPaymentMethods()
        {
            return Ok(await _paymentMethodService.GetAllPaymentMethodsAsync());
        }

        
        [HttpPost]
        public async Task<IActionResult> AddPaymenyMethod([FromBody] RequestPaymentMethod dto)
        {
            var createdDto = await _paymentMethodService.AddPaymentMethodAsync(dto);
            return CreatedAtAction(nameof(GetPaymentMethodById), new { id = createdDto.Id }, createdDto);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePaymentMethod(int id, [FromBody] RequestPaymentMethod dto)
        {
            var updated = await _paymentMethodService.UpdatePaymentMethodAsync(id, dto);
            return updated != null ? Ok(updated) : NotFound();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentMethod(int id)
        {
            await _paymentMethodService.DeletePaymentMethodAsync(id);
            return NoContent();
        }
    }
}
