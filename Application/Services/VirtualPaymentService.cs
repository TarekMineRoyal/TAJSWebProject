// Application/Services/VirtualPaymentService.cs
using Application.DTOs.Payment;
using Application.IRepositories;
using Application.IServices;
using Domain.Entities.AppEntities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class VirtualPaymentService : IVirtualPaymentService
    {
        private readonly IPaymentMethodService _paymentMethodService;
        private readonly IPaymentService _paymentService;
        private readonly IPaymentTransactionService _paymentTransactionService;
        private readonly IGenericRepository<Payment> _paymentRepo;

        public VirtualPaymentService(
            IPaymentMethodService paymentMethodService,
            IPaymentService paymentService,
            IPaymentTransactionService paymentTransactionService,
            IGenericRepository<Payment> paymentRepo)
        {
            _paymentMethodService = paymentMethodService;
            _paymentService = paymentService;
            _paymentTransactionService = paymentTransactionService;
            _paymentRepo = paymentRepo;
        }

        public async Task<object> MakeDeposit(int bookingId, decimal amount)
        {
            // 1. Get PayPal payment method
            var paymentMethods = await _paymentMethodService.GetAllPaymentMethodsAsync();
            var payPalMethod = paymentMethods.FirstOrDefault(p => p.PaymentMethod.Equals("PayPal", StringComparison.OrdinalIgnoreCase));

            if (payPalMethod == null)
            {
                throw new Exception("PayPal payment method not found. Please seed the database.");
            }

            // 2. Find the payment associated with the booking
            var payments = await _paymentService.GetAllPayments();
            var payment = payments.FirstOrDefault(p => p.BookingId == bookingId);
            if (payment == null)
            {
                throw new Exception($"Payment for booking ID {bookingId} not found.");
            }

            // 3. Make a deposit transaction
            var depositTransactionRequest = new RequestPaymentTransactionDTO
            {
                PaymentId = payment.Id,
                Amount = amount,
                TransactionType = TType.Deposit,
                TransactionDate = DateTime.UtcNow,
                PaymentMethodId = payPalMethod.Id
            };
            var depositTransactionResponse = await _paymentTransactionService.AddPaymentTransaction(depositTransactionRequest);

            // 4. Update the payment's status and total amount paid
            var paymentEntity = await _paymentRepo.GetByIdAsync(payment.Id);
            paymentEntity.AmountPaid += amount;

            if (paymentEntity.AmountPaid >= paymentEntity.AmountDue)
            {
                paymentEntity.Status = StatusEnum.Complete;
            }
            else
            {
                paymentEntity.Status = StatusEnum.Pending;
            }
            await _paymentRepo.UpdateAsync(payment.Id, paymentEntity);
            await _paymentRepo.SaveChangesAsync();

            return new
            {
                Message = "Deposit successful.",
                PaymentId = payment.Id,
                AmountDeposited = amount,
                TotalAmountPaid = paymentEntity.AmountPaid,
                TransactionDetails = depositTransactionResponse
            };
        }

        public async Task<object> MakeRefund(int bookingId, decimal amount)
        {
            // 1. Get PayPal payment method
            var paymentMethods = await _paymentMethodService.GetAllPaymentMethodsAsync();
            var payPalMethod = paymentMethods.FirstOrDefault(p => p.PaymentMethod.Equals("PayPal", StringComparison.OrdinalIgnoreCase));

            if (payPalMethod == null)
            {
                throw new Exception("PayPal payment method not found. Please seed the database.");
            }

            // 2. Find the payment associated with the booking
            var payments = await _paymentService.GetAllPayments();
            var payment = payments.FirstOrDefault(p => p.BookingId == bookingId);
            if (payment == null)
            {
                throw new Exception($"Payment for booking ID {bookingId} not found.");
            }

            var paymentEntity = await _paymentRepo.GetByIdAsync(payment.Id);

            if (amount > paymentEntity.AmountPaid)
            {
                throw new Exception("Refund amount cannot be greater than the amount paid.");
            }

            // 3. Make a refund transaction
            var refundTransactionRequest = new RequestPaymentTransactionDTO
            {
                PaymentId = payment.Id,
                Amount = amount,
                TransactionType = TType.Refund,
                TransactionDate = DateTime.UtcNow,
                PaymentMethodId = payPalMethod.Id
            };
            var refundTransactionResponse = await _paymentTransactionService.AddPaymentTransaction(refundTransactionRequest);

            // 4. Update the payment's status and total amount paid
            paymentEntity.AmountPaid -= amount;
            paymentEntity.Status = StatusEnum.Refund;
            await _paymentRepo.UpdateAsync(payment.Id, paymentEntity);
            await _paymentRepo.SaveChangesAsync();

            return new
            {
                Message = "Refund successful.",
                PaymentId = payment.Id,
                AmountRefunded = amount,
                TotalAmountPaid = paymentEntity.AmountPaid,
                TransactionDetails = refundTransactionResponse
            };
        }
    }
}