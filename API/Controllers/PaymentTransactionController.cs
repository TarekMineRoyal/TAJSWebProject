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
        public PaymentTransactionController(IPaymentTransactionService paymentTransactionService)
        {
            _paymentTransactionService = paymentTransactionService;
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
            return CreatedAtAction(nameof(GetTransactionById), new { id = createdDto.Id }, createdDto);
        }

    }
}
