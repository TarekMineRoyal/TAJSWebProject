using Application.DTOs.Payment;
using Application.IRepositories;
using Application.IServices;
using AutoMapper;
using Domain.Entities.AppEntities;
using System;
using System.Linq;
using System.Threading.Tasks;
using Stripe;

namespace Application.Services
{
    public class PaymentTransactionService : IPaymentTransactionService
    {
        private readonly IGenericRepository<PaymentTransaction> _paymentTransactionRepo;
        private readonly IGenericRepository<Domain.Entities.AppEntities.PaymentMethod> _paymentMethodRepo;
        private readonly IPayPalService _payPalService;
        private readonly IStripeService _stripeService;
        private readonly IMapper _mapper;

        public PaymentTransactionService(
            IGenericRepository<PaymentTransaction> paymentTransactionRepo,
            IGenericRepository<Domain.Entities.AppEntities.PaymentMethod> paymentMethodRepo,
            IPayPalService payPalService,
            IStripeService stripeService,
            IMapper mapper)
        {
            _paymentTransactionRepo = paymentTransactionRepo;
            _paymentMethodRepo = paymentMethodRepo;
            _payPalService = payPalService;
            _stripeService = stripeService;
            _mapper = mapper;
        }

        public async Task<ResponsePaymentTransactionDTO> AddPaymentTransaction(RequestPaymentTransactionDTO addTransactionDto)
        {
            var paymentMethod = await _paymentMethodRepo.GetByIdAsync(addTransactionDto.PaymentMethodId);
            if (paymentMethod == null)
            {
                throw new Exception("Payment method not found.");
            }

            var transaction = _mapper.Map<PaymentTransaction>(addTransactionDto);

            if (paymentMethod.Method.Equals("PayPal", StringComparison.OrdinalIgnoreCase))
            {
                if (addTransactionDto.TransactionType == TType.Deposit)
                {
                    var order = await _payPalService.CreateOrderAsync(addTransactionDto.Amount, "USD");
                    var capturedOrder = await _payPalService.CaptureOrderAsync(order.Id);

                    transaction.PayPalOrderId = order.Id;
                    transaction.PayPalCaptureId = capturedOrder.PurchaseUnits[0].Payments.Captures[0].Id;
                }
                else if (addTransactionDto.TransactionType == TType.Refund)
                {
                    var originalTransaction = await _paymentTransactionRepo.GetFirstOrDefaultAsync(
                        t => t.PaymentId == addTransactionDto.PaymentId && t.TransactionType == TType.Deposit && t.PayPalCaptureId != null
                    );
                    if (originalTransaction?.PayPalCaptureId == null)
                    {
                        throw new Exception("Original PayPal deposit transaction not found, cannot refund.");
                    }
                    var response = await _payPalService.RefundPaymentAsync(originalTransaction.PayPalCaptureId, addTransactionDto.Amount, "USD");
                    var refund = response.Result<PayPalCheckoutSdk.Payments.Refund>();
                    transaction.PayPalRefundId = refund.Id;
                }
            }
            else if (paymentMethod.Method.Equals("Stripe", StringComparison.OrdinalIgnoreCase))
            {
                if (addTransactionDto.TransactionType == TType.Deposit)
                {
                    var paymentIntent = await _stripeService.CreatePaymentIntentAsync(addTransactionDto.Amount, "USD");
                    transaction.StripePaymentIntentId = paymentIntent.Id;
                }
                else if (addTransactionDto.TransactionType == TType.Refund)
                {
                    var originalTransaction = await _paymentTransactionRepo.GetFirstOrDefaultAsync(
                        t => t.PaymentId == addTransactionDto.PaymentId && t.TransactionType == TType.Deposit && t.StripePaymentIntentId != null
                    );
                    if (originalTransaction?.StripePaymentIntentId == null)
                    {
                        throw new Exception("Original Stripe deposit transaction not found, cannot refund.");
                    }
                    var refund = await _stripeService.CreateRefundAsync(originalTransaction.StripePaymentIntentId, addTransactionDto.Amount);
                    transaction.StripeRefundId = refund.Id;
                }
            }

            var addedTransaction = await _paymentTransactionRepo.AddAsync(transaction);
            await _paymentTransactionRepo.SaveChangesAsync();
            return _mapper.Map<ResponsePaymentTransactionDTO>(addedTransaction);
        }

        public async Task<ResponsePaymentTransactionDTO> GetPaymentTransactionById(int id)
        {
            var paymentTransaction = await _paymentTransactionRepo.GetByIdAsync(id);
            return _mapper.Map<ResponsePaymentTransactionDTO>(paymentTransaction);
        }

        public async Task<IEnumerable<ResponsePaymentTransactionDTO>?> GetAllPaymentTransactions()
        {
            var paymentTransactions = await _paymentTransactionRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<ResponsePaymentTransactionDTO>>(paymentTransactions);
        }
    }
}