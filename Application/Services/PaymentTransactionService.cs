using Application.DTOs.Payment;
using Application.IRepositories;
using Application.IServices;
using AutoMapper;
using Domain.Entities.AppEntities;

namespace Application.Services
{
    public class PaymentTransactionService : IPaymentTransactionService
    {
        private readonly IGenericRepository<PaymentTransaction> _transactionRepo;
        private readonly IStripeService _stripeService;
        private readonly IPayPalService _payPalService;
        private readonly IMapper _mapper;

        // Inject all necessary services in the constructor
        public PaymentTransactionService(
            IGenericRepository<PaymentTransaction> transactionRepo,
            IStripeService stripeService,
            IPayPalService payPalService,
            IMapper mapper)
        {
            _transactionRepo = transactionRepo;
            _stripeService = stripeService;
            _payPalService = payPalService;
            _mapper = mapper;
        }

        public async Task<ResponsePaymentTransactionDTO> AddPaymentTransaction(RequestPaymentTransactionDTO addTransactionDto)
        {
            var transaction = _mapper.Map<PaymentTransaction>(addTransactionDto);

            // Assuming you have IDs for payment methods stored in your database
            // Let's assume 1-6 are Stripe (card, etc.) and 7 is PayPal
            if (addTransactionDto.PaymentMethodId == 2) // PayPal
            {
                var payPalOrder = await _payPalService.CreateOrderAsync(addTransactionDto.Amount, "USD");
                transaction.PayPalOrderId = payPalOrder.Id;
            }
            else // Stripe (or other card-based methods)
            {
                var paymentIntent = await _stripeService.CreatePaymentIntentAsync(addTransactionDto.Amount, "USD");
                transaction.StripePaymentIntentId = paymentIntent.Id;
            }

            var newTransaction = await _transactionRepo.AddAsync(transaction);
            await _transactionRepo.SaveChangesAsync();

            return _mapper.Map<ResponsePaymentTransactionDTO>(newTransaction);
        }

        // ... other methods in the service ...
        public async Task<IEnumerable<ResponsePaymentTransactionDTO>?> GetAllPaymentTransactions()
        {
            var paymentTransactions = await _transactionRepo.GetAllAsync();
            var paymentTransactionsDto = new List<ResponsePaymentTransactionDTO>();
            if (paymentTransactions != null)
            {
                foreach (PaymentTransaction transaction in paymentTransactions)
                {
                    paymentTransactionsDto.Add(_mapper.Map<ResponsePaymentTransactionDTO>(transaction));
                }

            }
            return paymentTransactionsDto;
        }

        public async Task<ResponsePaymentTransactionDTO> GetPaymentTransactionById(int id)
        {
            var paymentTransaction = await _transactionRepo.GetByIdAsync(id);
            var paymentTransactionDto = _mapper.Map<ResponsePaymentTransactionDTO>(paymentTransaction);
            return paymentTransactionDto;
        }
    }
}