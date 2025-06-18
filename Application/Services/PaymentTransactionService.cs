using Application.DTOs.Payment;
using Application.IRepositories;
using Application.IServices;
using AutoMapper;
using Domain.Entities.AppEntities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PaymentTransactionService : IPaymentTransactionService
    {
        private readonly IGenericRepository<PaymentTransaction> _paymentTransactionRepo;
        private readonly IGenericRepository<Payment> _paymentRepo;
        private readonly IGenericRepository<PaymentMethod> _paymentMethodRepo;
        private readonly IPayPalService _payPalService;
        private readonly IStripeService _stripeService;
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentTransactionService(
            IGenericRepository<PaymentTransaction> paymentTransactionRepo,
            IGenericRepository<Payment> paymentRepo,
            IGenericRepository<PaymentMethod> paymentMethodRepo,
            IPayPalService payPalService,
            IStripeService stripeService,
            IPaymentService paymentService,
            IMapper mapper)
        {
            _paymentTransactionRepo = paymentTransactionRepo;
            _paymentRepo = paymentRepo;
            _paymentMethodRepo = paymentMethodRepo;
            _payPalService = payPalService;
            _stripeService = stripeService;
            _paymentService = paymentService;
            _mapper = mapper;
        }

        public async Task<string> CreatePayPalOrderAsync(int bookingId)
        {
            var payments = await _paymentService.GetPaymentsByBookingId(bookingId);
            var payment = payments.FirstOrDefault();

            if (payment == null || payment.AmountDue <= 0)
            {
                throw new Exception("Valid payment record for the booking not found or amount is zero.");
            }

            var order = await _payPalService.CreateOrderAsync(payment.AmountDue, "USD");

            var payPalMethod = await _paymentMethodRepo.GetFirstOrDefaultAsync(pm => pm.Method == "PayPal");
            if (payPalMethod == null)
            {
                throw new Exception("PayPal payment method not found in the database.");
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

            await _paymentTransactionRepo.AddAsync(transaction);
            await _paymentTransactionRepo.SaveChangesAsync();

            return order.Id;
        }

        public async Task<object> CapturePayPalOrderAsync(string orderId)
        {
            var capturedOrder = await _payPalService.CaptureOrderAsync(orderId);
            var captureId = capturedOrder.PurchaseUnits[0].Payments.Captures[0].Id;

            var transaction = await _paymentTransactionRepo.GetFirstOrDefaultAsync(t => t.PayPalOrderId == orderId);

            if (transaction == null)
            {
                throw new Exception("Transaction not found for this Order ID.");
            }

            transaction.PayPalCaptureId = captureId;
            transaction.TransactionType = TType.Final;

            await _paymentTransactionRepo.UpdateAsync(transaction.Id, transaction);

            var payment = await _paymentRepo.GetByIdAsync(transaction.PaymentId);
            if (payment != null)
            {
                payment.AmountPaid += transaction.Amount;
                if (payment.AmountPaid >= payment.AmountDue)
                {
                    payment.Status = StatusEnum.Complete;
                }
                await _paymentRepo.UpdateAsync(payment.Id, payment);
            }

            await _paymentRepo.SaveChangesAsync();

            return capturedOrder;
        }


        // --- Other existing service methods ---
        public async Task<ResponsePaymentTransactionDTO> AddPaymentTransaction(RequestPaymentTransactionDTO addTransactionDto)
        {
            var paymentMethod = await _paymentMethodRepo.GetByIdAsync(addTransactionDto.PaymentMethodId);
            if (paymentMethod == null)
            {
                throw new Exception("Payment method not found.");
            }

            var transaction = _mapper.Map<PaymentTransaction>(addTransactionDto);

            // This logic is for a different flow, but we leave it for now.
            if (paymentMethod.Method.Equals("Stripe", StringComparison.OrdinalIgnoreCase))
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
